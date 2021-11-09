namespace FinCRM.DataAccess.CQRS.Queries
{
    using FinCRM.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    // Będzie nam ściągać Klienta po Id
    public class GetClientQuery : QueryBase<Client>
    {
        public int Id { get; set; }

        public override async Task<Client> Execute(CRMStorageContext context)
        {
            var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == this.Id);
            return client;
        }
    }
}
