using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProductCatalog.Infrastructure.Data.Common
{
    public class ListRepository : IRepository
    {
        private List<object> dbSets = new List<object>();

        protected List<T> DbSet<T>() where T : class
        {
            object dbSet = dbSets.FirstOrDefault(s => s.GetType() == typeof(List<T>));

            if(dbSet == null)
            {
                dbSet = new List<T>();
                dbSets.Add(dbSet);
            }

            return (List<T>)dbSet;
        }


        public void Add<T>(T entity) where T : class
        {
            string keyProperty = GetKeyPropertyName<T>();
            PropertyInfo pi = typeof(T).GetProperty(keyProperty);

            if (pi.PropertyType == typeof(int))
            {
                pi.SetValue(entity, DbSet<T>().Count + 1);
            }

            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public void Delete<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }

        public void Delete<T>(object id) where T : class
        {
            T entity = GetByID<T>(id);

            Delete(entity);
        }

        public void Dispose()
        {
            dbSets = null;
        }

        public T GetByID<T>(object id) where T : class
        {
            string keyProperty = GetKeyPropertyName<T>();
            T entity = null;

            if (keyProperty != null)
            {
                PropertyInfo pi = typeof(T).GetProperty(keyProperty);

                foreach (var item in DbSet<T>())
                {
                    if (pi.GetValue(item).Equals(id))
                    {
                        entity = item;
                        break;
                    }
                }
            }

            if(entity != null)
            {
                return entity;
            }

            throw new KeyNotFoundException("No entity with providet Id found");
        }

        public int SaveChanges()
        {
            return 1;
        }

        public void Update<T>(T entity) where T : class
        {
           string keyProperty = GetKeyPropertyName<T>();

            PropertyInfo pi = typeof(T).GetProperty(keyProperty);

            T item = GetByID<T>(pi.GetValue(entity));

            if (item != null)
            {
                int index = DbSet<T>().IndexOf(item);
                DbSet<T>()[index] = entity;
            }
        }

        private string GetKeyPropertyName<T>() where T : class
        {
            string keyProperty = null;
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if(Attribute.IsDefined(property, typeof(KeyAttribute)))
                {
                    keyProperty = property.Name;
                    break;
                }
            }

            if (keyProperty == null)
            {
                keyProperty = properties
                    .Where(p => p.Name.ToUpper() == "ID")
                    .Select(p => p.Name)
                    .FirstOrDefault();
            }

            if (keyProperty != null)
            {
                return keyProperty;
            }
            else
            {
                throw new MemberAccessException("No key property found.");
            }
        }
    }
}
