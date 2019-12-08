using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Database.IRepository
{
    public interface IRepository<T>
    {
        int Count(Expression<Func<T, bool>> filter);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetQuery(Expression<Func<T, bool>> filter);
        T GetSingle(Expression<Func<T, bool>> filter);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        IQueryable<T> GetQueryAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(Expression<Func<T, bool>> filter);
        //RawSqlRepository GetParsedOrDefaultValue(string sql);
    }
}
