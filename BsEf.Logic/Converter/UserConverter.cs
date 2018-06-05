using BsEf.Entities;
using BsEf.Logic.ViewModels.User;

namespace BsEf.Logic.Converter
{
    public static class UserConverter
    {
        public static UserViewModel ToUserViewModel(this User us)
        {
            return new UserViewModel
            {
                UserNo = us.UserNo,
                Id = us.Id,
                UserName = us.UserName,
                Sex = us.Sex.ToString(),
                Age = us.Age,
                DeleteState=us.DeleteState.ToString()
            };
        }
    }
}