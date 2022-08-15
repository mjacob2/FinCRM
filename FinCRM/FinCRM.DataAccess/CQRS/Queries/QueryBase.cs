using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{

    public abstract class QueryBase<TResoult>
    {
        public abstract Task<TResoult> Execute(CRMStorageContext context);

    }
}
