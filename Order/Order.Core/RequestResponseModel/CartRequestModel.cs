namespace Order.Core.RequestResponseModel
{
    public record CartRequestModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

