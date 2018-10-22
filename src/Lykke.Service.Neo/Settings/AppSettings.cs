using Lykke.Service.Neo.Core.Settings.ServiceSettings;
using Lykke.Service.Neo.Core.Settings.SlackNotifications;

namespace Lykke.Service.Neo.Core.Settings
{
    public class AppSettings
    {
        public NeoSettings NeoService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
