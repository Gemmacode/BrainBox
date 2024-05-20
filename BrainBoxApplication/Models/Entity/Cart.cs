using System.ComponentModel.DataAnnotations.Schema;

namespace BrainBoxApplication.Models.Entity
{
    public class Cart : BaseEntity
    {
        public Guid CartId { get; set; } = Guid.NewGuid();
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; } 
        public virtual List<Product> Products { get; set; }
        
       
    }
}
