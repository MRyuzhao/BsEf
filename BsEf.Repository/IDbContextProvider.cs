using System;
using Castle.Windsor;
using Data;

namespace BsEf.Repository
{
    public interface IDbContextProvider : IDisposable
    {
        BsEfDbContext GetTrainingDbContext();
    }

    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }
        protected virtual void DisposeCore()
        {
        }
    }

    public class DbContextProvider : Disposable, IDbContextProvider
    {
        private readonly IWindsorContainer _container;

        public DbContextProvider(IWindsorContainer container)
        {
            _container = container;
        }
        public BsEfDbContext GetTrainingDbContext()
        {
            var dbContext = _container.Resolve<BsEfDbContext>();
            return dbContext;
        }
    }
    public class DbCtxForServiceProvider : Disposable, IDbContextProvider
    {
        public BsEfDbContext DbContext = new BsEfDbContext();
        public BsEfDbContext GetTrainingDbContext()
        {
            return DbContext;
        }
    }
}
