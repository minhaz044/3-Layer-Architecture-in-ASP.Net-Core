using Database.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
