using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{
    public class GetMeQuery : QueryBase<User>
    {
        public int UserId { get; set; }

        public override async Task<User> Execute(CRMStorageContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == this.UserId);
            return user;
        }
    }
}