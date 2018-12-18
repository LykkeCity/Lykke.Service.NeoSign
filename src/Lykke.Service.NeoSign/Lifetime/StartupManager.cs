using System;
using System.IO;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using Lykke.Sdk;

namespace Lykke.Service.NeoSign.Lifetime
{
    public class StartupManager:IStartupManager
    {
        public async Task StartAsync()
        {
            Console.WriteLine("Content of protocol.json file");
            Console.WriteLine(await File.ReadAllTextAsync("protocol.json"));
            Console.WriteLine("-------------");
        }
    }
}
