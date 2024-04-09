namespace BrainBoxApplication.Entity
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public string ProductName { get; set; }   
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalCost { get; set; }
        public string ProductQuantity { get; set; }        
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        
    }
}
