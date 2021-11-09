




// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.
// Odkąd używamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówił.




/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }
        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }
        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            //entities.Update(entity); //Ten wiersz był usunięty u Kamizelicha
            return context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(s => s.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}*/