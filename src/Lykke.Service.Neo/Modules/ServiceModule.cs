using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Log;
using Lykke.Service.Neo.Core.Services;
using Lykke.Service.Neo.Core.Settings.ServiceSettings;
using Lykke.Service.Neo.Services;
using Lykke.SettingsReader;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.Neo.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<NeoSettings> _settings;
        private readonly ILog _log;

        public ServiceModule(IReloadingManager<NeoSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();
        }
    }
}
