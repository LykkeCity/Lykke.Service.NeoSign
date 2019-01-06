using System;
using System.Linq;
using AsyncFriendlyStackTrace;
using Common;
using Lykke.Common.Api.Contract.Responses;
using Lykke.Common.ApiLibrary.Contract;
using Lykke.Service.BlockchainApi.Contract.Transactions;
using Lykke.Service.NeoApi.Helpers.Transaction;
using Microsoft.AspNetCore.Mvc;
using NeoModules.Core.KeyPair;
using NeoModules.NEP6.Models;
using NeoModules.NEP6.Transactions;


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
                var tx = TransactionSerializer.Deserialize(request.TransactionContext);

                var keyPair = new KeyPair(Wallet.GetPrivateKeyFromWif(request.PrivateKeys.Single()));

                var signature = Transaction.Sign(keyPair, tx, false);
           
                var invocationScript = NeoModules.Core.Helper.HexToBytes(("40" + signature.ToHexString()));
                var verificationScript = Helper.CreateSignatureRedeemScript(keyPair.PublicKey);

                tx.Witnesses = new[]
                {
                    new Witness
                    {
                        InvocationScript = invocationScript,
                        VerificationScript = verificationScript
                    }
                };

                return Ok(new SignedTransactionResponse
                {
                    SignedTransaction = TransactionSerializer.Serialize(tx)
                });
            }

            catch (Exception e)
            {
                return BadRequest(ErrorResponse.Create(e.ToAsyncString()));
            }
        }
    }
}
