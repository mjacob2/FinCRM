using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{
    public class GetMeQuery : QueryBase<User>
    {
        // PRzy wywoływaniu GetClientQuery będziemy podawać clientId w propercji
        public int UserId { get; set; }

        public override async Task<User> Execute(CRMStorageContext context)
        {
            // Tu wywołujemy z naszej bazy pierwsze query, które spełni warunek, że jego Id zgadza się z naszym clientId.
            //FirstOrDefaultAsync - w przypadku, gdybyśmy wołali o Id, którego nie ma w bazie, to dostaniemy null
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == this.UserId);
            return user;
        }
    }
}