namespace BrainBoxApplication.Entity
{
    public class CartItem : BaseEntity
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }        
        public Guid ProductId { get; set; }        
        public string Quantity { get; set; }

       
    }
}
