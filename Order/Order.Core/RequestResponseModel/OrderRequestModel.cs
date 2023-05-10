using Order.Core.ObjectModel;

namespace Order.Core.RequestResponseModel
{
    public record OrderRequestModel
    {
        //public OrderRequestModel()
        //{
        //    orderDetails = new HashSet<OrderDetails>();
        //}

        public int OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public long Discount { get; set; }

        public decimal OrderPriceExGST { get; set; }

        public decimal OrderPriceIncGST { get; set; }

        public int PaymentModeId { get; set; }

        public int PaymentTransID { get; set; }

        public string? OrderStatus { get; set; }

        public bool IsDeleted { get; set; }
    }
}
