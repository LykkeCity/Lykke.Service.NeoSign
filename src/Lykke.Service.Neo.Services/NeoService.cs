using System;
using System.Security.Cryptography;
using Common.Log;
using Lykke.Service.Neo.Core.Services;
using Neo.Implementations.Wallets.NEP6;
using Neo.Wallets;

namespace Lykke.Service.Neo.Services
{
    public class NeoService: INeoService
    {
        private readonly ILog _log; 
        
        public NeoService(ILog log)
        {
            _log = log; 
        }
        
        public string GeneratePassword()
        {
            var cryptRng = new RNGCryptoServiceProvider();
            var tokenBuffer = new byte[Settings.Default.PasswordLength];
            cryptRng.GetBytes(tokenBuffer);
            return Convert.ToBase64String(tokenBuffer);
        }
         
        public WalletAccount CreateWalletAccount(string password, string walletName)
        {
            var walletPath = $"{Settings.Default.Paths.WalletPath}\\{walletName}.json";
            var wallet = new NEP6Wallet(walletPath);
            wallet.Unlock(password);
            var account = wallet.CreateAccount();
            wallet.Save();
            
            return account;
        }
    }
}
