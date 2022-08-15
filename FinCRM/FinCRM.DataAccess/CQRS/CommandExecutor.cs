namespace FinCRM.DataAccess.CQRS
{
using System.Threading.Tasks;
using FinCRM.DataAccess.CQRS.Commands;
using FinCRM.DataAccess.CQRS;
using FinCRM.DataAccess.CQRS.Commands;

    public class CommandExecutor : ICommandExecutor
    {
        private readonly CRMStorageContext context;

        public CommandExecutor(CRMStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}