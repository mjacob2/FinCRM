using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{

    public class AddClientCommand : CommandBase<Client, Client>
    {

        

        public override async Task<Client> Execute(CRMStorageContext context)
        {
            await context.Clients.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}