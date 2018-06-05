using BsEf.Entities;
using BsEf.Logic.UiCommand.Login;
using BsEf.Logic.ViewModels.User;

namespace BsEf.Logic.ILogic
{
    public interface ILoginLogic
    {
        UserViewModel Login(LoginUiCommand command);
    }
}