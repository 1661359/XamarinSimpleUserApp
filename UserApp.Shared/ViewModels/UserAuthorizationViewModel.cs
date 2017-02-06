using UserApp.Shared.Contracts;

namespace UserApp.Shared.ViewModels
{
    public class UserAuthorizationViewModel
    {
        public string UserName
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public AuthorizationAnswer AuthorizationAnswer
        {
            get;
            set;
        }
    }
}
