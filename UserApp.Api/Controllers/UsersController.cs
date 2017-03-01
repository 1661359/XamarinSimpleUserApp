using System;
using System.Net;
using System.Web.Http;
using UserApp.Shared.Contracts;
using UserApp.Shared.ViewModels;


namespace UserApp.Api.Controllers
{
    public class UsersController : ApiController
    {

        [HttpPost]
        [ActionName("Login")]
        public UserAuthorizationViewModel Login([FromBody]UserAuthorizationViewModel userAuthorizationViewModel)
        {
            if (userAuthorizationViewModel == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            const string baseUserName = "raiden";
            var result = new UserAuthorizationViewModel
            {
                UserName = userAuthorizationViewModel.UserName,
                Token = Guid.NewGuid().ToString(),
                AuthorizationAnswer =
                    userAuthorizationViewModel.
                    UserName == baseUserName ? AuthorizationAnswer.Ok : AuthorizationAnswer.WrongUserName
            };
            return result;
        }

    }
}