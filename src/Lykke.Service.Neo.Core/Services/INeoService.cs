using System.Collections.Generic;
using Lykke.Service.Neo.Core.Domain.Health;
using Neo.Wallets;

namespace Lykke.Service.Neo.Core.Services
{
    
    public interface INeoService
    {
        string GeneratePassword();
        WalletAccount CreateWalletAccount(string password, string walletName);
    }
}
