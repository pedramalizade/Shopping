using System.Linq;

namespace shopping_2
{
    public class Authentication : IAuthentication
    {
        public string Login(string userName, string password)
        {
            if (userName != null)
            {
                foreach (var item in Storage.Users)
                {
                    if (item.UserName == userName && item.Password == password)
                    {
                        if(item.Role == Enums.UserRoleEnum.User)
                        {
                            Storage.CurrentUser = item;
                            return "User";
                        }
                        else
                        {
                            Storage.CurrentUser = item;
                            return "Admun";
                        }
                    }
                }
            }
            return "UserName or Password Incorrect.";
        }

        public bool Register(User user)
        {
            foreach(var item in Storage.Users)
            {
                if (item.UserName != user.UserName)
                {
                    Storage.Users.Add(user);
                    return true;
                }
            }
            return false;
        }
    }
}
