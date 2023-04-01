using SkylineVUpdater.ENums;

namespace SkylineVUpdater.Functions
{
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void Send(string message, LogType type)
        {
            // Unterdrücke Default-Warnungen
            if (Setting.Boolean("general:extendLog") == false && type == LogType.Default)
            {
                // Vorgang abbrechen
                return;
            }

            // Je Type
            switch (type)
            {
                case LogType.Success: Console.ForegroundColor = ConsoleColor.Green; break;
                case LogType.Warning: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case LogType.Failed: Console.ForegroundColor = ConsoleColor.Red; break;
                default: Console.ForegroundColor = ConsoleColor.White; break;
            }

            Console.WriteLine($"[{DateTime.Now}] {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}