using System;
using System.Web.Http;
using UserApp.Shared.Contracts;
using UserApp.Shared.ViewModels;


namespace UserApp.Api.Controllers
{
    public class UsersController : ApiController
    {

        [HttpPost]
        [ActionName("Login")]
        public UserAuthorizationViewModel Login([FromBody]string userName)
        {
            const string baseUserName = "raiden";
            var result = new UserAuthorizationViewModel
            {
                UserName = userName,
                Token = Guid.NewGuid().ToString(),
                AuthorizationAnswer =
                    userName == baseUserName ? AuthorizationAnswer.Ok : AuthorizationAnswer.WrongUserName
            };
            return result;
        }

    }
}