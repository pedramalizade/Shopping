using shopping_2.Enums;
using System.Collections.Specialized;

namespace shopping_2
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.registered;

        public Product(int id, string name, string price,string description, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Quantity = quantity;
        }
    }
}
