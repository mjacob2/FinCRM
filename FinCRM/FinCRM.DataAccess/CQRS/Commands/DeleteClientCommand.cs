using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class DeleteClientCommand : CommandBase<Client, Client>
    {
        public override async Task<Client> Execute(CRMStorageContext context)
        {
            context.Clients.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}