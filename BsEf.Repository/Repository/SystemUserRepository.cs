using BsEf.Entities;
using BsEf.Repository.IRepository;

namespace BsEf.Repository.Repository
{
    public class SystemUserRepository : BaseRepository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}