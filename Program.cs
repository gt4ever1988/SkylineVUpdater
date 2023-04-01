using SkylineVUpdater.Classes;
using SkylineVUpdater.ENums;
using SkylineVUpdater.Functions;
using System.Diagnostics;

namespace SkylineVUpdater
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            while (true)
            {
                await DoSyncAsync();
                Log.Send("", LogType.Default);
                Log.Send("", LogType.Default);
                Log.Send($"Waiting for next Check ... in {Setting.Double("general:updateCheckSeconds")} Seconds", LogType.Default);
                await Task.Delay(TimeSpan.FromSeconds(Setting.Double("general:updateCheckSeconds")));
                Log.Send("", LogType.Default);
                Log.Send("", LogType.Default);
            }
        }

        private static async Task DoSyncAsync()
        {
            // Logging
            Log.Send($"Start Sync ...", LogType.Default);

            // Hole Server-Status
            bool serverOff = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(
                $"{Setting.String("general:altVRootPath")}\\{Setting.String("general:altVServerExe")}"), Environment.MachineName).Length == 0;

            // Liste
            List<string> works = new();

            // Gehe Dateien laut alt:V durch
            foreach (UpdateJSONFile file in await AltV.GetFilesAsync())
            {
                // Datei gefunden
                if (file.FileExist)
                {
                    // Identische Version
                    if (file.SameVersion)
                    {
                        // Logging
                        Log.Send($"- {file.FileFullPath}: Nothing to update, current Version {file.Version}", LogType.Default);
                    }
                    // Unterschiedliche Version
                    else
                    {
                        // Auto-Update notwendig
                        if (Setting.Boolean("general:autoUpdateWhenServerOff") && serverOff)
                        {
                            // Update
                            file.CreateBackup();
                            await file.DownloadNewVersionAsync();

                            // Arbeit/Logging
                            works.Add($"> **{file.FileFullPath}**: Updated to new version {file.Version}");
                            Log.Send($"- {file.FileFullPath}: Updated to new version {file.Version}", LogType.Success);
                        }
                        // Kein Auto-Update notwendig
                        else
                        {
                            // Arbeit/Logging
                            works.Add($"> **{file.FileFullPath}**: New version need ({file.Version})");
                            Log.Send($"- {file.FileFullPath}: New version need ({file.Version})", LogType.Warning);
                        }
                    }
                }
                // Datei nicht gefunden
                else
                {
                    // Auto-Update notwendig
                    if (Setting.Boolean("general:autoUpdateWhenServerOff") && serverOff)
                    {
                        // Update
                        await file.DownloadNewVersionAsync();

                        // Arbeit/Logging
                        works.Add($"> **{file.FileFullPath}**: Downloaded version {file.Version}");
                        Log.Send($"- {file.FileFullPath}: Downloaded version {file.Version}", LogType.Success);
                    }
                    // Kein Auto-Update notwendig
                    else
                    {
                        // Arbeit/Logging
                        works.Add($"> **{file.FileFullPath}**: Download need with version {file.Version}");
                        Log.Send($"- {file.FileFullPath}: Download need with version  {file.Version}", LogType.Warning);
                    }
                }
            }

            // Erstelle Discord-Nachricht bei Änderung
            if (works.Count > 0 && Setting.ULong("discord:webhookId") != 0)
                await Functions.Discord.SendAsync($"A difference to the current alt:V update status for path " +
                    $"**{Setting.String("general:altVRootPath")}** on **{Setting.String("general:altVBranch")}**-Branch " +
                    $"for **{Setting.String("general:altVOS")}**-OS " +
                    $"was found:\n{string.Join("\n", works)}");

            // Logging
            Log.Send($"Sync with {works.Count} work(s) completed.", LogType.Success);
        }
    }
}