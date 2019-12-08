using Database.Context;
using Database.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
        }
        public int Count(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Count(filter);
        }
        public void Delete(int id)
        {
            T emtity = _dbSet.Find(id);
            _dbSet.Remove(emtity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Delete(Expression<Func<T, bool>> filter)
        {
            foreach (var entity in Get(filter))
            {
                Delete(entity);
            }
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return GetQuery(filter).ToList();
        }
        public IEnumerable<T> GetAll()
        {
            return GetQueryAll().ToList();
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }
        public IEnumerable<T> GetQuery(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter);
        }
        public IQueryable<T> GetQueryAll()
        {
            return _dbSet;
        }
        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                _context.Set<T>().Attach(entity);
            }
            catch (Exception e)
            {
                _context.Entry(entity).State = EntityState.Detached;
                _context.Set<T>().Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
