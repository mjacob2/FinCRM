using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Commands
{
    //TParameter będzie danymi, które wpływają na modyfikację. Np. tyuł i autor książki, którą chcemy dodać
    // TParameter będzie mógł być zdefiniowany podczas tworzenia komendy, dlatego jest generykiem
    public abstract class CommandBase<TParameter, TResoult>
    {
        public TParameter? Parameter { get; set; }

        //abstract bo to jest baza, nigdy nie będzie instancji tego obiektu.
        public abstract Task<TResoult> Execute(CRMStorageContext context);

    }
}
