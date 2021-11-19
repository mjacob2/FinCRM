using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{

    // Każde query będzie musiało zwrócić jakiś TResoult
    //Kiedy będziemy np. pytać o liste ksoażęk, to TResoult będzie właśnie tą listą
    public abstract class QueryBase<TResoult>
    {
        //kontextem jest baza danych
        public abstract Task<TResoult> Execute(CRMStorageContext context);

        //Rezultatem będzie Task z tym Trezultatem, który jest podany w Query
    }
}
