using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{

    public abstract class CommandBase<TParameter, TResoult>
    {
        public TParameter? Parameter { get; set; }

        public abstract Task<TResoult> Execute(CRMStorageContext context);

    }
}
