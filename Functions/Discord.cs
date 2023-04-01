using Discord.Webhook;
using SkylineVUpdater.ENums;

namespace SkylineVUpdater.Functions
{
    public class Discord
    {
        /// <summary>
        /// Sende Nachricht
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task SendAsync(string message)
        {
            try
            {
                // Hook
                DiscordWebhookClient webhookClient = new(Setting.ULong("discord:webhookId"), Setting.String("discord:webhookToken"));

                // Füge Benutzermarkierungen hinzu
                if (Setting.ULong("discord:notificationUserId1") != 0) message = $"<@{Setting.ULong("discord:notificationUserId1")}> {message}";
                if (Setting.ULong("discord:notificationUserId2") != 0) message = $"<@{Setting.ULong("discord:notificationUserId2")}> {message}";
                if (Setting.ULong("discord:notificationUserId3") != 0) message = $"<@{Setting.ULong("discord:notificationUserId3")}> {message}";

                // Kürze Nachricht wenn über Limit
                if (!string.IsNullOrEmpty(message) && message.Length > 1750) message = message[..1750];

                // Sende Nachricht
                await webhookClient.SendMessageAsync(message, false, null, Setting.String("discord:author"));
            }
            catch (Exception ex)
            {
                // Logging
                Log.Send($"- Discord-Message cannot send: {ex.Message}", LogType.Failed);
            }
        }
    }
}