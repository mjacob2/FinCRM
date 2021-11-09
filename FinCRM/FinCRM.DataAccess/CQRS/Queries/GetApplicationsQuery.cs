namespace FinCRM.DataAccess.CQRS.Queries
{
    using FinCRM.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    // Będzie nam ściagać wszystkich Klientów
    public class GetApplicationtsQuery : QueryBase<List<Application>>
    {
        public int Id { get; set; }

        public override Task<List<Application>> Execute(CRMStorageContext context)
        {
            return context.Applications.ToListAsync();

        }
    }
}