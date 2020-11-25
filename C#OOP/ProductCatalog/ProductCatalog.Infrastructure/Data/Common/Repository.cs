using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        protected DbContext Context { get; set; }

        public Repository(ApplicationDBContext _context)
        {
            Context = _context;
        }

        protected DbSet<T> DbSet<T>() where T: class
        {
            return Context.Set<T>();
        }
        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(object id) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public T GetByID<T>(object id) where T : class
        {
            return DbSet<T>().Find(id);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            DbSet<T>().Update(entity);
        }
    }
}
