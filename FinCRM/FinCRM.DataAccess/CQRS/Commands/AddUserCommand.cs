using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {

        public override async Task<User> Execute(CRMStorageContext context)
        {
            //do kontextu/bazy dodajemy ten nowy Client, który przyszedł
            await context.Users.AddAsync(this.Parameter);
            //zawsze po operacji dodawania do bazy, trzeba zrobić SaveChanges
            await context.SaveChangesAsync();
            //i chcemy dostać w rezultacie już updejtowaną encję
            return this.Parameter;
        }
    }
}
