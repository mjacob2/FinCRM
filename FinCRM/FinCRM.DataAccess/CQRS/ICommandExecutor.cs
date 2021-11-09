using FinCRM.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResoult> Execute<TParameters, TResoult>(CommandBase<TParameters, TResoult> command);
    }
}
