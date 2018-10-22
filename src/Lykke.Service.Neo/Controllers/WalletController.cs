using System.Security.Cryptography;
using Lykke.Service.Neo.Models;
using Microsoft.AspNetCore.Mvc;
using Neo.SmartContract;
using Neo.Wallets;

namespace Lykke.Service.Neo.Controllers
{    
    [Route("api/[controller]")]
    public class WalletController : Controller
    {

        [HttpPost]
        public WalletCreationResponse CreateWallet()
        {
            using (var key = CngKey.Create(CngAlgorithm.ECDsaP256, null, new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextArchiving }))
            {
                var privateKey = key.Export(CngKeyBlobFormat.EccPrivateBlob);
                var account = new KeyPair(privateKey);

                return new WalletCreationResponse
                {
                    AddressContext = null,
                    PrivateKey = account.Export(),
                    PublicAddress = Contract.CreateSignatureContract(account.PublicKey).Address
                };
            }
        }
    }
}
