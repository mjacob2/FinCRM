using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class LoginUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(CRMStorageContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            return this.Parameter;
        }
    }
}