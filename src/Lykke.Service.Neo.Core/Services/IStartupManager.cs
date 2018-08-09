using System.Threading.Tasks;

namespace Lykke.Service.Neo.Core.Services
{
    public interface IStartupManager
    {
        Task StartAsync();
    }
}