using System.Configuration;

namespace SkylineVUpdater.Functions
{
    public class Setting
    {
        public static string? String(string name)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(name))
            {
                return ConfigurationManager.AppSettings[name];
            }

            return string.Empty;
        }

        public static bool Boolean(string name)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(name) &&
                bool.TryParse(ConfigurationManager.AppSettings[name], out bool result))
            {
                return result;
            }

            return false;
        }

        public static double Double(string name)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(name) &&
                double.TryParse(ConfigurationManager.AppSettings[name], out double result))
            {
                return result;
            }

            return 0;
        }

        public static ulong ULong(string name)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(name) &&
                ulong.TryParse(ConfigurationManager.AppSettings[name], out ulong result))
            {
                return result;
            }

            return 0;
        }
    }
}
