using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    // Pierwszy CLient to TParameter, któy jesto nwoym klientem i wpływa na zmianę bazy poprzez jego dodanie
    // TRezultatem tez jest Client, który finalnie dodamy do bazy
    public class AddClientCommand : CommandBase<Client, Client>
    {

        

        public override async Task<Client> Execute(CRMStorageContext context)
        {
            //do kontextu/bazy dodajemy ten nowy Client, który przyszedł
            await context.Clients.AddAsync(this.Parameter);
            //zawsze po operacji dodawania do bazy, trzeba zrobić SaveChanges
            await context.SaveChangesAsync();
            //i chcemy dostać w rezultacie już updejtowaną encję
            return this.Parameter;
        }
    }
}