using Microsoft.EntityFrameworkCore;
using Payment.Core.Domain;
using System.Collections.Generic;

namespace Payment.Core.IServices
{
    public interface IApplicationDbContext
    {
        DbSet<PaymentDto> Payments { get; set; }
        Task<int> SaveChangesAsync();
    }
}
