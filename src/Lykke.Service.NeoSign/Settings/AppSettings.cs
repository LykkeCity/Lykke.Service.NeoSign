using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.NeoSign.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        //mainnet/testnet configuration via protocol.json file during teamcity build
    }
}
