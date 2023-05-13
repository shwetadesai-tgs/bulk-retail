using Support.Core.Models;

namespace Support.Core.IRepositories
{
    public interface ISupportRepository
    {
        Task<List<Supports>> GetAllSupportsAsync();
    }
}
