namespace Lykke.Service.Neo.Models
{
    public class WalletResponse
    {
        public byte[] PrivateKey { get; set; }

        public string PublicAddress { get; set; }
        public string FromAddressContext { get; set; }
        public string Password { get; set; }
    }
}
