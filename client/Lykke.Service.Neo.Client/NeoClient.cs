using System;
using Common.Log;

namespace Lykke.Service.Neo.Client
{
    public class NeoClient : INeoClient, IDisposable
    {
        private readonly ILog _log;

        public NeoClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
