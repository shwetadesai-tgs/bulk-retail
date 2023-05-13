using Microsoft.EntityFrameworkCore;
using Payment.Core.Domain;
using Payment.Core.IRepositories;
using Payment.Core.IServices;
using Stripe;


namespace Payment.Infrastructure.Repositories
{
    public class PaymentServices : IPaymentServices
    {
        #region Fields

        private readonly IPaymentRepository _paymentRepository;
        private DbSet<PaymentDto> entities;

        #endregion

        #region Ctor

        public PaymentServices(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        #endregion

        #region Methods

        public async Task DeletePaymentAsync(PaymentDto payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _paymentRepository.DeletePaymentAsync(payment.Id);
        }

        public async Task DeletePaymentsAsync(IList<PaymentDto> payments)
        {
            if (payments == null)
                throw new ArgumentNullException(nameof(payments));

            foreach (var payment in payments)
            {
                entities.Remove(payment);
                //await _paymentRepository.DeletePayment();
            }
        }

        public async Task<IList<PaymentDto>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllPaymentsAsync();
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int paymentId)
        {
            return await _paymentRepository.GetPaymentByIdAsync(paymentId);
        }

        public async Task<IList<PaymentDto>> GetPaymentsByIdsAsync(int[] paymentIds)
        {
            return await _paymentRepository.GetPaymentsByIdsAsync(paymentIds);
        }

        public async Task InsertPaymentAsync(PaymentDto payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            await _paymentRepository.InsertPaymentAsync(payment);
        }

        public async Task UpdatePaymentAsync(PaymentDto payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            await _paymentRepository.UpdatePaymentAsync(payment);
        }

        #endregion

        #region Payment Integration Methods
        public void ChargeService(long amount = 1000, string description = "Example charge")
        {
            StripeConfiguration.ApiKey = "sk_test_51N7B73SJBNPrziOqOIFHrGBioY9U47mfCdXFJBWg8wmbNas1VvqcpGGEvsI3HyQqnslcNfcjPz8SIxLjpexCMlhW00QLqBdpz5";

            var options = new ChargeCreateOptions
            {
                Amount = amount,
                Currency = "usd",
                Description = "Example charge",
                Source = "tok_visa", // replace with an actual card token or source ID
            };

            var service = new ChargeService();
            Charge charge = service.Create(options);
        }


        public void CreateCustomer(string email = "customer@example.com")
        {
            StripeConfiguration.ApiKey = "sk_test_51N7B73SJBNPrziOqOIFHrGBioY9U47mfCdXFJBWg8wmbNas1VvqcpGGEvsI3HyQqnslcNfcjPz8SIxLjpexCMlhW00QLqBdpz5";

            var options = new CustomerCreateOptions
            {
                Email = email
            };

            var service = new CustomerService();
            Customer customer = service.Create(options);

            // Newly created customer is returned
            Console.WriteLine(customer.Email);
            Console.WriteLine(customer.Id);
        }

        public void GetCustomer(string id = "cus_1234")
        {
            StripeConfiguration.ApiKey = "sk_test_51N7B73SJBNPrziOqOIFHrGBioY9U47mfCdXFJBWg8wmbNas1VvqcpGGEvsI3HyQqnslcNfcjPz8SIxLjpexCMlhW00QLqBdpz5";

            var service = new CustomerService();
            Customer customer = service.Get(id);

            Console.WriteLine(customer.Email);
        }

        #endregion
    }
}
