using Newtonsoft.Json;
using SkylineVUpdater.Classes;

namespace SkylineVUpdater.Functions
{
    public class AltV
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<UpdateJSONFile>> GetFilesAsync()
        {
            string cdnUrl = "https://cdn.alt-mp.com";
            List<UpdateJSONFile> files = new();

            if (Setting.Boolean("module:coreClr"))
                files.AddRange(await GetJSONDataAsync($"{cdnUrl}/coreclr-module/" +
                    $"{Setting.String("general:altVBranch")}/{Setting.String("general:altVOS")}/update.json"));

            if (Setting.Boolean("module:js"))
                files.AddRange(await GetJSONDataAsync($"{cdnUrl}/js-module/" +
                    $"{Setting.String("general:altVBranch")}/{Setting.String("general:altVOS")}/update.json"));

            if (Setting.Boolean("module:jsBytecode"))
                files.AddRange(await GetJSONDataAsync($"{cdnUrl}/js-bytecode-module/" +
                    $"{Setting.String("general:altVBranch")}/{Setting.String("general:altVOS")}/update.json"));

            if (Setting.Boolean("module:voiceServer"))
                files.AddRange(await GetJSONDataAsync($"{cdnUrl}/voice-server/" +
                    $"{Setting.String("general:altVBranch")}/{Setting.String("general:altVOS")}/update.json"));

            if (Setting.Boolean("module:server"))
                files.AddRange(await GetJSONDataAsync($"{cdnUrl}/server/" +
                    $"{Setting.String("general:altVBranch")}/{Setting.String("general:altVOS")}/update.json"));

            if (Setting.Boolean("module:serverBin"))
                files.AddRange(await GetJSONDataAsync($"{cdnUrl}/data/" +
                    $"{Setting.String("general:altVBranch")}/update.json"));

            // Rückgabe
            return files;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatePath"></param>
        /// <returns></returns>
        private static async Task<List<UpdateJSONFile>> GetJSONDataAsync(string updatePath)
        {
            try
            {
                // Erstelle Client
                using var httpClient = new HttpClient();

                // Lade JSON-Daten
                string jsonData = await httpClient.GetStringAsync($"{updatePath}?ts={DateTime.Now.Ticks}");

                // Lade aktuelle Daten
                UpdateJSON? updateInfo = JsonConvert.DeserializeObject<UpdateJSON>(jsonData);

                if (updateInfo == null || updateInfo.Files.Count == 0) return new List<UpdateJSONFile>();

                // Rückgabe
                return updateInfo.Files.Select(x => new UpdateJSONFile(updateInfo.Version, updatePath, x.Key, x.Value)).ToList();
            }
            catch (Exception)
            {
                return new List<UpdateJSONFile>();
            }
        }
    }
}