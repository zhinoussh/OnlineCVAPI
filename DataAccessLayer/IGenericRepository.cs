using System;
using System.Linq;
using System.Linq.Expressions;
using OnlineCVAPI.Models;

namespace OnlineCVAPI.DataAccessLayer
{
    public interface IGenericRepository<T> where T : TEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        int Create(T entity);
        void Update(T entity);
        void Delete(T enitity);
    }
}