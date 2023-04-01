using SkylineVUpdater.Functions;

namespace SkylineVUpdater.Classes
{
    public class UpdateJSONFile
    {
        public string? Version { get; set; }

        public string UpdateURL { get; set; }

        public string FileNameOriginal { get; set; }

        public string SHA1 { get; set; }

        private string FilePath => FileNameOriginal.Replace("/", "\\");

        public string FileFullPath => $"{Setting.String("general:altVRootPath")}\\{FilePath}";

        public bool FileExist => File.Exists(FileFullPath);

        public bool SameVersion
        {
            get
            {
                if (FileExist)
                {
                    using var sha1 = System.Security.Cryptography.SHA1.Create();
                    using var stream = File.OpenRead(FileFullPath);
                    var hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower() == SHA1;
                }

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateBackup() => File.Move(FileFullPath, $"{FileFullPath}_{DateTime.Now:dd.MM.yyyy_HH.mm.ss}");

        /// <summary>
        /// 
        /// </summary>
        public async Task DownloadNewVersionAsync()
        {
            // Erstelle Client für Download
            using HttpClient client = new();

            // Lade neue Version
            HttpResponseMessage response = await client.GetAsync(UpdateURL.Replace("update.json", FilePath));
            response.EnsureSuccessStatusCode();

            // Speichern der Datei
            using Stream contentStream = await response.Content.ReadAsStreamAsync();
            using FileStream fileStream = new(FileFullPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            await contentStream.CopyToAsync(fileStream);
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="version"></param>
        /// <param name="updateUrl"></param>
        /// <param name="fileNameOriginal"></param>
        /// <param name="sHA1"></param>
        public UpdateJSONFile(string? version, string updateUrl, string fileNameOriginal, string sHA1)
        {
            Version = version;
            UpdateURL = updateUrl;
            FileNameOriginal = fileNameOriginal;
            SHA1 = sHA1;
        }
    }
}