using shopping_2;
using shopping_2.Enums;

AuthenticationManu();


void AuthenticationManu()
{
    IAuthentication authentication = new Authentication();
    Console.Write("1: Login\n2: Register\n3: Exit");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {


                Console.WriteLine("Enter Your Name: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter Your Password: ");
                string password = Console.ReadLine();
                var loginResult = authentication.Login(userName, password);
                if ("User" == loginResult)
                {
                    UserManu();
                }
                else if (loginResult == "Admin")
                {
                    AdminManu();
                }
                else
                {
                    Console.WriteLine(loginResult);
                }
                break;
            }

        case "2":
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter family: ");
                string family = Console.ReadLine();
                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();
                Console.WriteLine("Enter Role (1: Admin, 2: User): ");
                int Role = int.Parse(Console.ReadLine());
                var id = Storage.Users.Count;
                User user = new User(id, password, name, family, email, (UserRoleEnum)Role);
                authentication.Register(user);
                break;
            }
        case "3":
            break;
        default:
            Console.WriteLine("Your Choice Is Invalid");
            break;

    }
}

void UserManu()
{
    Console.Clear();
    Console.WriteLine("*****************");
    Console.WriteLine("    USER MENU    ");
    Console.WriteLine("1: Show Products & buy. ");
    Console.WriteLine("2: Show Shopping Cart.");
    Console.WriteLine("3: Show My Purchase.");
    Console.WriteLine("4: Logout.");
    string choice = Console.ReadLine();
    IShopService shopService = new ShopService();
    switch (choice)
    {
        case "1":
            {
                shopService.ShowProducts();
                Console.Write("Enter Product Name to Buy: ");
                string productName = Console.ReadLine();
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                var addResult = shopService.AddProductToShoppingCart(quantity, productName, Storage.CurrentUser.UserName);
                if (!addResult)
                {
                    Console.WriteLine("Not add.");
                }
                else
                {
                    Console.WriteLine("Added to shopping cart.");
                }
                break;
            }
        case "2":
            {
                shopService.ShowUserShoppingCartProducts(Storage.CurrentUser.UserName);
                break;
            }
    }
}

void AdminManu()
{

}
