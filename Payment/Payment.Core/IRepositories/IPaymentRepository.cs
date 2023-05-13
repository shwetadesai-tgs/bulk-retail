using Payment.Core.Domain;

namespace Payment.Core.IRepositories
{
    public interface IPaymentRepository
    {
        Task<List<PaymentDto>> GetAllPaymentsAsync();
        Task<PaymentDto> GetPaymentByIdAsync(int id);
        Task<List<PaymentDto>> GetPaymentsByIdsAsync(int[] paymentIds);
        Task<List<PaymentDto>> GetPaymentByNameAsync(string name);
        Task InsertPaymentAsync(PaymentDto payment);
        Task<bool> UpdatePaymentAsync(PaymentDto payment);
        Task<bool> DeletePaymentAsync(int id);
    }
}
