namespace FinCRM.DataAccess.CQRS
{
    using FinCRM.DataAccess;
    using FinCRM.DataAccess.CQRS.Queries;
    using System.Threading.Tasks;

    public class QueryExecutor : IQueryExecutor
    {
        private readonly CRMStorageContext context;

        public QueryExecutor(CRMStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}