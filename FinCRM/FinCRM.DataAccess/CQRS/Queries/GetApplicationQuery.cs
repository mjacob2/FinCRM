using FinCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{
    public class GetApplicationQuery : QueryBase<Application>
    {
        public int ApplicationId { get; set; }

        public override async Task<Application> Execute(CRMStorageContext context)
        {
            var application = await context.Applications.FirstOrDefaultAsync(x => x.Id == this.ApplicationId);
            return application;
        }
    }
}