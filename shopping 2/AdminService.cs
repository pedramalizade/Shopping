using shopping_2.Enums;

namespace shopping_2
{
    public class AdminService : IAdminService
    {
        public bool AddProduct(Product product)
        {
            if (product != null)
            {
                foreach (var item in Storage.Products)
                {
                    if(product.Name == item.Name)
                    {
                        return false;
                    }
                    else
                    {
                        Storage.Products.Add(product);
                        return true;
                    }
                }
            }
                
            return false;
        }

        public void ChangeQuantity(string productName, int quantity)
        {
            if (quantity > 0)
            {
                foreach(var item in Storage.Products)
                {
                    if (item.Name == productName)
                    {
                        item.Quantity = quantity;
                    }
                }
            }

        }

        public void ConfrimProducts(string productName, string userName)
        {
            foreach (var user in Storage.Users)
            {
                if (user.UserName == userName)
                {
                    foreach (var item in user.ShoppingCart.Products)
                    {
                        if (item.Status == StatusEnum.registered)
                        {
                            Console.WriteLine($"name = {item.Name}");
                            Console.WriteLine($"Description = {item.Description}");
                            Console.WriteLine($"Price = {item.Price}");
                            Console.WriteLine($"Quantity  {item.Quantity}");
                            Console.WriteLine("---------------------------------------------");
                        }
                    }
                    foreach (var product in user.ShoppingCart.Products)
                    {
                        if (product.Name == productName)
                        {
                            product.Status = StatusEnum.confirmed;
                            foreach (var storageProduct in Storage.Products)
                            {
                                if (storageProduct.Name == productName)
                                {
                                    storageProduct.Quantity -= product.Quantity;
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool RemoveProduct(string productName)
        {
            if (productName != null)
            {
                foreach (var item in Storage.Products)
                {
                    if (productName == item.Name)
                    {
                        Storage.Products.Remove(item);
                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }
                }
            }
            return false;
        }

        public void ShowAllUsersProducts()
        {
            foreach (var user in Storage.Users)
            {
                Console.WriteLine($"UserName = {user.UserName}");
                foreach (var product in user.Products)
                {
                    Console.WriteLine("**** PRODUCTS ****");
                    Console.WriteLine($"name = {product.Name}");
                    Console.WriteLine($"Description = {product.Description}");
                    Console.WriteLine($"Price = {product.Price}");
                    Console.WriteLine($"Quantity  {product.Quantity}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }
    }
}
