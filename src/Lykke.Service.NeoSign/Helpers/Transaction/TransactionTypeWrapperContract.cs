using NeoModules.NEP6.Transactions;

namespace Lykke.Service.NeoSign.Helpers.Transaction
{
    public class TransactionTypeWrapperContract
    {
        public string Type { get; set; }

        public string Data { get; set; }

        public static  TransactionTypeWrapperContract Create(TransactionType type, string data)
        {
            return new TransactionTypeWrapperContract
            {
                Data = data,
                Type = type.ToString()
            };
        }
    }
}
