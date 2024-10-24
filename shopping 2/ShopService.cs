using shopping_2.Enums;

namespace shopping_2
{
    public class ShopService : IShopService
    {
        public bool AddProductToShoppingCart(int quantity, string productName, string userName)
        {
            if (productName == null)
            {
                return false;
            }
            else
            {
                foreach (var item in Storage.Products)
                {
                    if (item.Name == productName)
                    {
                        item.Quantity = quantity;
                        foreach (var user in Storage.Users)
                        {
                            if (user.UserName == userName)
                            {
                                user.ShoppingCart.Products.Add(item);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool FinalizePurchase(string productName, string userName)
        {
            var products = ShowUserShoppingCartProducts(userName);
            foreach (var item in products)
            {
                if (item.Name == productName && item.Status == StatusEnum.confirmed)
                {
                    foreach (var user in Storage.Users)
                    {
                        if (user.UserName == userName)
                        {
                            user.Products.Add(item);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void ShowProducts()
        {
            foreach (var item in Storage.Products)
            {
                Console.WriteLine($"name = {item.Name}");
                Console.WriteLine($"Description = {item.Description}");
                Console.WriteLine($"Price = {item.Price}");
                Console.WriteLine($"Quantity  {item.Quantity}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public void ShowUserProducts(string userName)
        {
            foreach (var user in Storage.Users)
            {
                if (user.UserName == userName)
                {
                    foreach (var item in user.Products)
                    {
                        Console.WriteLine($"name = {item.Name}");
                        Console.WriteLine($"Description = {item.Description}");
                        Console.WriteLine($"Price = {item.Price}");
                        Console.WriteLine($"Quantity  {item.Quantity}");
                        Console.WriteLine("---------------------------------------------");
                    }
                }
            }

        }

        public List<Product> ShowUserShoppingCartProducts(string userName)
        {
            foreach (var user in Storage.Users)
            {
                if (user.UserName == userName)
                {
                    foreach (var item in user.ShoppingCart.Products)
                    {
                        Console.WriteLine($"name = {item.Name}");
                        Console.WriteLine($"Description = {item.Description}");
                        Console.WriteLine($"Price = {item.Price}");
                        Console.WriteLine($"Quantity  {item.Quantity}");
                        Console.WriteLine("---------------------------------------------");
                    }
                    return user.ShoppingCart.Products;
                }
            }
            return null;
        }
    }
}
