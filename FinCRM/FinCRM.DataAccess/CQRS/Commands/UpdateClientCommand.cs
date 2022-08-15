using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class UpdateClientCommand : CommandBase<Client, Client>
    {

        //public int Id { get; set; }

        public override async Task<Client> Execute(CRMStorageContext context)
        {
            context.Clients.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}