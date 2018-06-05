using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BsEf.Common;
using Data;

namespace BsEf.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly IDbContextProvider _dbContextProvider;

        protected BsEfDbContext DbContext
        {
            get
            {
                return _dbContextProvider.GetTrainingDbContext();
            }
        }
        protected BaseRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }
        public TEntity Add(TEntity t)
        {
            DbContext.Set<TEntity>().Add(t);
            SafeSaveChanges();

            return t;
        }
        public void Edit(TEntity t)
        {
            var entry = DbContext.Entry(t);
            DbContext.Set<TEntity>().Attach(t);
            entry.State = EntityState.Modified;
            SafeSaveChanges();
        }
        public void Delete(int id)
        {
            var entity = Get(id);
            DbContext.Set<TEntity>().Remove(entity);
            SafeSaveChanges();
        }
        public TEntity Get(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> GetPagingData(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, string orderByPropertyName, bool isAsc, out int totalRecordes)
        {
            var source = DbContext.Set<TEntity>().Where(filter);
            totalRecordes = source.Count();
            return source.SortByProperty(orderByPropertyName, isAsc)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .AsQueryable().ToList();
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return DbContext.Set<TEntity>().Where(filter).ToList();
        }

        private void SafeSaveChanges()
        {
            foreach (var error in DbContext.GetValidationErrors())
            {
                var entityType = error.Entry.Entity.GetType().BaseType;

                foreach (var validationError in error.ValidationErrors)
                {
                    var property = entityType.GetProperty(validationError.PropertyName);
                    if (property.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
                    {
                        property.GetValue(error.Entry.Entity, null);
                    }
                }
            }

            DbContext.SaveChanges();
        }
    }
}