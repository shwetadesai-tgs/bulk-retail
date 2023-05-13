namespace Payment.Core.Domain
{
    public class PaymentDto : BaseEntity
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
