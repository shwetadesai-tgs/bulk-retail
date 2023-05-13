using Support.Core.Models;

namespace Support.Core.IServices
{
    public interface ISupportServices
    {
        Task<IList<Supports>> GetAllSupportsAsync();
    }
}
