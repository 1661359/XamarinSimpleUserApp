using UserApp.Shared.Contracts;

namespace UserApp
{
    public static class AppSessionConfig
    {
        public static string UserName
        {
            get;
            set;
        }

        public static string Token
        {
            get;
            set;
        }

        public static bool IsLoggedIn
        {
            get;
            set;
        }

        public static AuthorizationAnswer LastAuthorizationAnswer
        {
            get;
            set;
        }
    }
}
