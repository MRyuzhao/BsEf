using System.Linq;
using BsEf.Common;
using BsEf.Common.TimeProvider;
using BsEf.Logic.Converter;
using BsEf.Logic.ILogic;
using BsEf.Logic.UiCommand.Login;
using BsEf.Logic.ViewModels.User;
using BsEf.Repository.IRepository;
using static System.String;

namespace BsEf.Logic.Logic
{
    public class LoginLogic : ILoginLogic
    {
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly ICurrentTimeProvider _currentTimeProvider;

        public LoginLogic(ISystemUserRepository systemUserRepository,
            ICurrentTimeProvider currentTimeProvider)
        {
            _systemUserRepository = systemUserRepository;
            _currentTimeProvider = currentTimeProvider;
        }

        public UserViewModel Login(LoginUiCommand command)
        {
            if (IsNullOrEmpty(command.Account)|| IsNullOrEmpty(command.Password))
            {
                throw new LogicException(ErrorMessage.UserLoginNull);
            }
            var currentUser = _systemUserRepository.GetAll(x =>
                x.LoginName == command.Account).SingleOrDefault();
            if (currentUser == null)
            {
                throw new LogicException(ErrorMessage.UserIsNotExist);
            }
            if (!PasswordHasher.ValidateHash(command.Password, currentUser.Password))
            {
                throw new LogicException(ErrorMessage.UserLoginFault);
            }

            currentUser.LastLoginDate = _currentTimeProvider.CurrentTime();
            _systemUserRepository.Edit(currentUser);
            var user = currentUser.User.ToLoginViewModel();
            return user;
        }
    }
}