using System;
using System.Data.Entity;
using BsEf.Repository.UnitOfWork;

namespace BsEf.Repository
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        public EntityFrameworkUnitOfWork(IDbContextProvider dbProvider)
        {
            _dbContext = dbProvider.GetTrainingDbContext();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}