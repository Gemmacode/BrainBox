using System.ComponentModel.DataAnnotations.Schema;

namespace BrainBoxApplication.Models.Entity
{
    public class Cart : BaseEntity
    {
        public Guid CartId { get; set; } = Guid.NewGuid();
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public List<Product> Products { get; set; }
        
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
    }
}
