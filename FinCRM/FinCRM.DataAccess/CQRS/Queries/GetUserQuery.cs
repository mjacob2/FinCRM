using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public string Username { get; set; }

        public override Task<User> Execute(CRMStorageContext context)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Username == this.Username);
        }
    }
}
