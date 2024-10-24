namespace shopping_2
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
