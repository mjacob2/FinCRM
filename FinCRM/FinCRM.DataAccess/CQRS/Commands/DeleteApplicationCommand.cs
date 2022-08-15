using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class DeleteApplicationCommand : CommandBase<Application, Application>
    {
        public override async Task<Application> Execute(CRMStorageContext context)
        {
            context.Applications.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }

    }
}
