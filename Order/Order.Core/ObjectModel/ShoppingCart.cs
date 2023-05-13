using BulkRetail.ProductService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Order.Core.ObjectModel
{
    [DataContract]
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Products = new HashSet<ProductModel>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int Qty { get; set; }

        [DataMember]
        public string? CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public virtual ICollection<ProductModel> Products { get; set; }
    }
}

