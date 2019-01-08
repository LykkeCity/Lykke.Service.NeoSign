using Common;

namespace Lykke.Service.NeoApi.Helpers.Transaction
{
    public static class TransactionSerializer
    {
        public static string Serialize(NeoModules.NEP6.Transactions.Transaction transaction)
        {
            return TransactionContract.FromDomain(transaction).ToJson().ToBase64();
        }

        public static NeoModules.NEP6.Transactions.Transaction Deserialize(string source)
        {
            return source.Base64ToString().DeserializeJson<TransactionContract>().ToDomain();
        }
    }
}
