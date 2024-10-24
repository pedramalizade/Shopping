using shopping_2.Enums;

namespace shopping_2
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserRoleEnum Role { get; set; }

        public List<Product> Products { get; set; } = new List<Product>(); // kharid karde

        public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();

        public User(int id, string password, string firstName, string lastName, string email ,UserRoleEnum role)
        {
            Id = id;
            UserName = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }
    }
}
