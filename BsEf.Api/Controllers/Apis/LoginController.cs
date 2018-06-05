using System.Web.Http;
using BsEf.Logic.ILogic;
using BsEf.Logic.UiCommand.Login;
using BsEf.Logic.ViewModels.User;

namespace BsEf.Api.Controllers.Apis
{
    public class LoginController: BaseApiController
    {
        private readonly ILoginLogic _loginLogic;

        public LoginController(ILoginLogic loginLogic)
        {
            _loginLogic = loginLogic;
        }

        [Route("api/logins/login")]
        [HttpPost]
        public UserViewModel Login([FromBody]LoginUiCommand command)
        {
             return _loginLogic.Login(command);
        }
    }
}