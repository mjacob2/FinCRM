using FinCRM.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    //Parametrem i rezultatem będzie Application, bo chcemy wziać obiekt Application, coś z nim porobić i go oddać.
    public class AddApplicationCommand : CommandBase<Application, Application>
    {
        public override async Task<Application> Execute(CRMStorageContext context)
        {
            //do kontextu dodajemy ten nowy Application, który przyszedł
            await context.Applications.AddAsync(this.Parameter);
            //zawsze po operacji dodawania do bazy, trzeba zrobić SaveChanges
            await context.SaveChangesAsync();
            //i chemy dostać w rezultacie już updejtowaną encję
            return this.Parameter;
        }
    }
}
