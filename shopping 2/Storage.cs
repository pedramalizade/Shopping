namespace shopping_2
{
    public static class Storage
    {
        public static List<Product> Products = new List<Product>();

        public static List<User> Users = new List<User>();

        public static User CurrentUser { get; set; }
    }
}
