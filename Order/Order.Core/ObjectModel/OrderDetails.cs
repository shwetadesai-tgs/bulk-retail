using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Order.Core.ObjectModel
{
    [DataContract]
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal NetPrice { get; set; }
        [DataMember]
        public int Discount { get; set; }
        [DataMember]
        public DateTime EstShippingDate { get; set; }
        [DataMember]
        public DateTime EstDeliveryDate { get; set; }
        [DataMember]
        public DateTime ActDeliveryDate { get; set; }
        [DataMember]
        public bool IsCancelProd { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public virtual Orders Orders { get; set; }
    }
}
