using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BsEf.Logic.ILogic;
using BsEf.Logic.UiCommand.User;

namespace BsEf.Api.Controllers.Apis
{
    public class UserController : BaseApiController
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [Route("api/user")]
        [HttpPost]
        public void Create(CreateUserCommand command)
        {
            //_userLogic.Create(command);
        }
    }
}