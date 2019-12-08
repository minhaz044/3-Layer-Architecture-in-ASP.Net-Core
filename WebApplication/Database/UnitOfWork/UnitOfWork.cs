using Database.Context;
using Database.IRepository;
using Database.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Database.UnitOfWork
{

        public class UnitOfWork : IUnitOfWork, IDisposable
        {
            private readonly AppDbContext _context;
            private bool _disposed;
            private readonly Hashtable _repositories;

            public UnitOfWork(AppDbContext WebAppDbContext)
            {
                _repositories = new Hashtable();
                _context = WebAppDbContext;
            }
            public IRepository<TData> Repository<TData>() where TData : class
            {
                var type = typeof(TData).Name;

                if (!_repositories.ContainsKey(type))
                {
                    _repositories.Add(type, new Repository<TData>(_context));
                }
                return (IRepository<TData>)_repositories[type];
            }
            public void Save()
            {
                _context.SaveChanges();
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            public virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                _disposed = true;
            }
        }
    
}
