using Payment.Core.Domain;

namespace Payment.Core.IServices
{
    public interface IPaymentServices
    {
        Task<PaymentDto> GetPaymentByIdAsync(int paymentId);

        /// <summary>
        /// Gets payments by identifier
        /// </summary>
        /// <param name="paymentIds">Payment identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the payments
        /// </returns>
        Task<IList<PaymentDto>> GetPaymentsByIdsAsync(int[] paymentIds);

        /// <summary>
        /// Inserts a payment
        /// </summary>
        /// <param name="payment">Payment</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertPaymentAsync(PaymentDto payment);

        /// <summary>
        /// Updates the payment
        /// </summary>
        /// <param name="payment">Payment</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdatePaymentAsync(PaymentDto payment);

        /// <summary>
        /// Delete a payment
        /// </summary>
        /// <param name="payment">Payment</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeletePaymentAsync(PaymentDto payment);

        /// <summary>
        /// Delete payments
        /// </summary>
        /// <param name="payments">Payments</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeletePaymentsAsync(IList<PaymentDto> payments);

        /// <summary>
        /// Gets all payments displayed on the home page
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the payments
        /// </returns>
        Task<IList<PaymentDto>> GetAllPaymentsAsync();
    }
}
