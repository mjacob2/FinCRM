namespace FinCRM.DataAccess.CQRS.Queries
{
    using FinCRM.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    // Będzie nam ściągać Klienta po Id
    //Rezultatewm będzie Klient
    public class GetClientQuery : QueryBase<Client>
    {
        // PRzy wywoływaniu GetClientQuery będziemy podawać clientId w propercji
        public int ClientId { get; set; }

        public override async Task<Client> Execute(CRMStorageContext context)
        {
            // Tu wywołujemy z naszej bazy pierwsze query, które spełni warunek, że jego Id zgadza się z naszym clientId.
            //FirstOrDefaultAsync - w przypadku, gdybyśmy wołali o Id, którego nie ma w bazie, to dostaniemy null
            var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == this.ClientId);
            return client;
        }
    }
}
