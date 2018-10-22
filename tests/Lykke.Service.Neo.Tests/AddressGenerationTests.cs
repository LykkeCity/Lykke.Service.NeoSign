using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Neo.Network.P2P.Payloads;
using Neo.SmartContract;
using Neo.Wallets;
using Xunit;

namespace Lykke.Service.NeoSign.Tests
{
    public class AddressGenerationTests
    {
        [Fact]
        public async Task Can_Generate_Address()
        {
            using (var key = CngKey.Create(CngAlgorithm.ECDsaP256, null, new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextArchiving }))
            {
                var privateKey = key.Export(CngKeyBlobFormat.EccPrivateBlob);
                var account = new KeyPair(privateKey);
                var ecpoint = account.PublicKey;


                var sc = Contract.CreateSignatureContract(account.PublicKey);

          


                var addr = sc.Address;

            }


            




        }

        [Fact]
        public async Task Can_Sign()
        {
            using (var key = CngKey.Create(CngAlgorithm.ECDsaP256, null, new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextArchiving }))
            {
                var privateKey = key.Export(CngKeyBlobFormat.EccPrivateBlob);
                var account = new KeyPair(privateKey);


                var sc = Contract.CreateSignatureContract(account.PublicKey);


                var context = ContractParametersContext.FromJson("");

                var signature = context.Verifiable.Sign(account);

                var isSigned = context.AddSignature(sc, account.PublicKey, signature);
            }

        }




        private void GenerateAddressFromPublicKey(KeyPair privateKey)
        {
            var sc = Contract.CreateSignatureContract(privateKey.PublicKey);
        }

    }
}
