namespace BlazorDemo
{
    public class MyDemoSrv
    {
        private string UserType { get; set; }
        public MyDemoSrv(string userType)
        {
            UserType = userType;
        }
        public string GetUserType()
        {
            return UserType;
        }
    }
}
