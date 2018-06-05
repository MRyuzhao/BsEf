using BsEf.Entities;
using BsEf.Repository.IRepository;

namespace BsEf.Repository.Repository
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        public UserRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}