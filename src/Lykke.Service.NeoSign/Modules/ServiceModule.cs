using Autofac;
using Lykke.Sdk;
using Lykke.Service.NeoSign.Lifetime;
using Lykke.Service.NeoSign.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.NeoSign.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();
        }
    }
}
