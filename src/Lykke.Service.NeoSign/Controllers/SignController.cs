using System;
using System.Linq;
using Lykke.Common.Api.Contract.Responses;
using Lykke.Common.ApiLibrary.Contract;
using Lykke.Service.BlockchainApi.Contract.Transactions;
using Microsoft.AspNetCore.Mvc;
using Neo;
using Neo.Cryptography;
using Neo.SmartContract;
using Neo.Wallets;


namespace Lykke.Service.NeoSign.Controllers
{
    [Route("api/[controller]")]
    public class SignController : Controller
    {

        [HttpPost]
        public IActionResult Sign([FromBody] SignTransactionRequest request)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ErrorResponseFactory.Create(ModelState));

            try
            {
                var privateKey = new KeyPair(
                    Wallet.GetPrivateKeyFromWIF(request.PrivateKeys.Single()));

                var sc = Contract.CreateSignatureContract(privateKey.PublicKey);

                var context = ContractParametersContext.FromJson(request.TransactionContext);

                var signature = context.Verifiable.Sign(privateKey);

                var isSigned = context.AddSignature(sc, privateKey.PublicKey, signature);

                if (!isSigned)
                {
                    return BadRequest(ErrorResponse.Create("Unable to sign transaction using provided private key"));
                }

                return Ok(new SignedTransactionResponse
                {
                    SignedTransaction = context.ToJson().ToString()
                });
            }

            catch (Exception e)
            {
                return BadRequest(ErrorResponse.Create(e.Message));
            }
        }
    }
}
