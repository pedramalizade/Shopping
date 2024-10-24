namespace shopping_2
{
    public interface IAdminService
    {
        public void ConfrimProducts(string productName, string userName);
        public bool AddProduct(Product product);
        public void ChangeQuantity(string productName, int quantity);
        public bool RemoveProduct(string productName);
        public void ShowAllUsersProducts();
    }
}
