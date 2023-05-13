using Microsoft.EntityFrameworkCore;
using Support.Core.IRepositories;
using Support.Core.IServices;
using Support.Core.Models;

namespace Product.Infrastructure.Repositories
{
    public class SupportServices : ISupportServices
    {
        #region Fields

        private readonly ISupportRepository _supportRepository;
        private DbSet<Supports> entities;

        #endregion

        #region Ctor

        public SupportServices(ISupportRepository supportRepository)
        {
            _supportRepository = supportRepository;
        }

        #endregion

        #region Methods
        public async Task<IList<Supports>> GetAllSupportsAsync()
        {
            return await _supportRepository.GetAllSupportsAsync();
        }
        #endregion
    }
}
