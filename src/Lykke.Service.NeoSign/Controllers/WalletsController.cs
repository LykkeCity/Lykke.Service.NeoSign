using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Lykke.Service.BlockchainApi.Contract.Wallets;
using Microsoft.AspNetCore.Mvc;
using Neo.SmartContract;
using Neo.Wallets;

namespace Lykke.Service.NeoSign.Controllers
{

    [Route("api/[controller]")]
    public class WalletsController : Controller
    {
        [HttpPost]
        public WalletResponse CreateWallet()
        {
            var randomData = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomData);
            }

            var privateKey = new KeyPair(randomData);

            return new WalletResponse
            {
                AddressContext = null,
                PrivateKey = privateKey.Export(),
                PublicAddress = Contract.CreateSignatureContract(privateKey.PublicKey).Address
            };
        }
    }
}
