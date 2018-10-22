using System.Security.Cryptography;
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
            using (var key = CngKey.Create(CngAlgorithm.ECDsaP256, 
                null, 
                new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextArchiving }))
            {
                var privateKey = new KeyPair(key.Export(CngKeyBlobFormat.EccPrivateBlob));

                return new WalletResponse
                {
                    AddressContext = null,
                    PrivateKey = privateKey.Export(),
                    PublicAddress = Contract.CreateSignatureContract(privateKey.PublicKey).Address
                };
            };
        }
    }
}
