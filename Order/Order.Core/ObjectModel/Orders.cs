using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Order.Core.ObjectModel
{
    [DataContract]
    public class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [DataMember]
        public int OrderNumber { get; set; }

        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public long Discount { get; set; }

        [DataMember]
        public decimal OrderPriceExGST { get; set; }

        [DataMember]
        public decimal OrderPriceIncGST { get; set; }

        [DataMember]
        public int PaymentModeId { get; set; }

        [DataMember]
        public int PaymentTransId { get; set; }

        [DataMember]
        public string? OrderStatus { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
