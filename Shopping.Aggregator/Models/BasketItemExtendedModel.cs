namespace Shopping.Aggregator.Models
{
    public class BasketItemExtendedModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string BookId { get; set; }
        public string Title { get; set; }

        //Product Related Additional Fields
        public string Genre { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}