using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class UpdateClientCommand : CommandBase<Client, Client>
      {

        //public int Id { get; set; }

        public override async Task<Client> Execute(CRMStorageContext context)
        {

            //var clientToUpdate = await context.Clients.FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);

            //this.Parameter.DateOfCreation = clientToUpdate.DateOfCreation;   

            //do kontextu dodajemy ten nowy Client, który przyszedł
            context.Clients.Update(this.Parameter);
            //zawsze po operacji dodawania do bazy, trzeba zrobić SaveChanges
            await context.SaveChangesAsync();
            //i chcemy dostać w rezultacie już zaktualizowaną encję
            return this.Parameter;
        }
    }
}