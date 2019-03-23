using System;

namespace Lykke.Service.NeoSign.Helpers.Transaction.Exceptions
{
    public class InvalidTransactionException:Exception
    {
        public InvalidTransactionException(string message = null) : base(message)
        {

        }
    }
}
