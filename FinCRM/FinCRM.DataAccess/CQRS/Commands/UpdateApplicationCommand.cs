using FinCRM.DataAccess.Entities;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    public class UpdateApplicationCommand : CommandBase<Application, Application>
    {

        //public int Id { get; set; }

        public override async Task<Application> Execute(CRMStorageContext context)
        {
            context.Applications.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}