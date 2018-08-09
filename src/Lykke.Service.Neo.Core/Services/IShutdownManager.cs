using System.Threading.Tasks;

namespace Lykke.Service.Neo.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}