using System;
using System.Collections.Generic;
using System.Linq;
using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinCRM.DataAccess
{

    // Implementuje Interfejs
    //JEst to mechanizm, który dostarcza Entity Framework
    public class Repository<T> : IRepository<T> where T : EntityBase // T musi być naszą encją
    {
        protected readonly CRMStorageContext context;
        private DbSet<T> entities;

        public Repository(CRMStorageContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}