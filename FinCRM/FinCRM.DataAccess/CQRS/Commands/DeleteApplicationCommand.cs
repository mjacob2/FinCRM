using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class DeleteApplicationCommand : CommandBase<Application, Application>
    {
        public override async Task<Application> Execute(CRMStorageContext context)
        {
            //do kontextu dodajemy ten nowy Application, który przyszedł
            context.Applications.Remove(this.Parameter);
            //zawsze po operacji dodawania do bazy, trzeba zrobić SaveChanges
            await context.SaveChangesAsync();
            //i chemy dostać w rezultacie już updejtowaną encję
            return this.Parameter;
        }

    }
}
