namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string BookId { get; set; }
        public string Title { get; set; }
    }
}