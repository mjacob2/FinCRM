using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class DeleteClientCommand : CommandBase<Client, Client>
    {
        public override async Task<Client> Execute(CRMStorageContext context)
        {
            //do kontextu dodajemy ten nowy Application, który przyszedł
            context.Clients.Remove(this.Parameter);
            //zawsze po operacji dodawania do bazy, trzeba zrobić SaveChanges
            await context.SaveChangesAsync();
            //i chemy dostać w rezultacie już updejtowaną encję
            return this.Parameter;
        }
    }
}