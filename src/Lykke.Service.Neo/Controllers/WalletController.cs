using System.ComponentModel.DataAnnotations;
using Lykke.Service.Neo.Core.Services;
using Lykke.Service.Neo.Models;
using Microsoft.AspNetCore.Mvc;
using Neo;

namespace Lykke.Service.Neo.Controllers
{    
    [Route("api/[controller]")]
    public class WalletController : Controller
    {
        private readonly INeoService _neoService;

        public WalletController(INeoService neoService)
        {
            _neoService = neoService;
        }

        [HttpPost]
        public WalletResponse Post([Required]string walletName, string fromAddressContext)
        {
            var password = _neoService.GeneratePassword();
            var walletAccount = _neoService.CreateWalletAccount(password: password, walletName: walletName); 

            return new WalletResponse()
            {
                PrivateKey = walletAccount.GetKey().PrivateKey,
                PublicAddress = walletAccount.Address,
                FromAddressContext = fromAddressContext,
                Password= password
            };
        }
    }
}
