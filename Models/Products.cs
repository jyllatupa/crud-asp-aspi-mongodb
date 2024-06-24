namespace ConsumirAPI_MongoDB.Models
{
    public class Products
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
