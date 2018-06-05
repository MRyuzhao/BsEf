using BsEf.Logic.ILogic;
using BsEf.Repository.IRepository;

namespace BsEf.Logic.Logic
{
    public class UserLogic:IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

    }
}