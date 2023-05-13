using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Support.Core.Models
{
    public class Supports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupportId { get; set; }
        [Required]
        public long SupportCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Email { get; set; }
        public int Status { get; set; }

    }
}
