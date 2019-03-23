using NeoModules.Core;
using NeoModules.NEP6.Transactions;

namespace Lykke.Service.NeoSign.Helpers.Transaction
{
    public class CoinReferenceContract
    {
        public string PrevHash { get; set; }

        public ushort PrevIndex { get; set; }

        public CoinReference ToDomain()
        {
            return new CoinReference
            {
                PrevHash = UInt256.Parse(PrevHash),
                PrevIndex = PrevIndex
            };
        }

        public static CoinReferenceContract FromDomain(CoinReference source)
        {
            return new CoinReferenceContract
            {
                PrevHash = source.PrevHash.ToString(),
                PrevIndex = source.PrevIndex
            };
        }
    }
}
