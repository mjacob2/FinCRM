namespace FinCRM.DataAccess.CQRS.Queries
{
    using FinCRM.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    // Będzie nam ściagać wszystkich Klientów
   public  class GetClientsQuery : QueryBase<List<Client>>
    {
        public int Id { get; set; }

        public override Task<List<Client>> Execute(CRMStorageContext context)
        {
            return context.Clients.ToListAsync();
 
        }
    }
}