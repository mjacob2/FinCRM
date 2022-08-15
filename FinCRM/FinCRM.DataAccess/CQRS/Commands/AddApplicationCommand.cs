using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class AddApplicationCommand : CommandBase<Application, Application>
    {
        public override async Task<Application> Execute(CRMStorageContext context)
        {
            await context.Applications.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
