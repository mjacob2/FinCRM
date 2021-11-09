using FinCRM.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace FinCRM.DataAccess
{
    public interface IQueryExecutor
    {
        Task<TResoult> Execute<TResoult>(QueryBase<TResoult> query);
    }
}
