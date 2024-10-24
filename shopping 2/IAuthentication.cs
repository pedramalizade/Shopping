namespace shopping_2
{
    public interface IAuthentication
    {
        public string Login(string userName, string password);
        public bool Register(User user);
    }
}
