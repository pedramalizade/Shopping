namespace shopping_2
{
    public interface IShopService
    {
        public void ShowProducts();
        public bool AddProductToShoppingCart(int quantity, string productName, string userName);
        public bool FinalizePurchase(string productName, string userName);
        public List<Product> ShowUserShoppingCartProducts(string userName);
        public void ShowUserProducts(string userName);

    }
}
