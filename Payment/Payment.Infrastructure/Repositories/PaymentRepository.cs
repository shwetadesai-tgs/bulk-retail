using Microsoft.EntityFrameworkCore;
using Payment.Core.Domain;
using Payment.Core.IRepositories;
using Payment.Core.IServices;

namespace Payment.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IApplicationDbContext _context;

        public PaymentRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentDto>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("entity");

            return await _context.Payments.FindAsync(id);
        }

        public async Task<List<PaymentDto>> GetPaymentByNameAsync(string name)
        {
            return await _context.Payments.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task InsertPaymentAsync(PaymentDto payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePaymentAsync(PaymentDto payment)
        {
            _context.Payments.Update(payment);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return false;
            }

            _context.Payments.Remove(payment);

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<List<PaymentDto>> GetPaymentsByIdsAsync(int[] paymentIds)
        {
            if (!paymentIds?.Any() ?? true)
                return new List<PaymentDto>();

            var entries = await _context.Payments.ToListAsync();

            //sort by passed identifiers
            var sortedEntries = new List<PaymentDto>();
            foreach (var id in paymentIds)
            {
                var sortedEntry = entries.Find(entry => entry.Id == id);
                if (sortedEntry != null)
                    sortedEntries.Add(sortedEntry);
            }

            return sortedEntries;
        }
    }
}
