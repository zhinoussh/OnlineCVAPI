using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineCVAPI.Models;

namespace OnlineCVAPI.DataAccessLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : TEntity
    {
        protected readonly OnlineCVDBContext _context;

        public GenericRepository(OnlineCVDBContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().Where(predicate);
        }
        public virtual int Create(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
            return entity.ID;
        }

        public virtual void Update(T entity)
        {
            //_context.Entry(entity).State = System.Data.EntityState.Modified;
            Save();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}