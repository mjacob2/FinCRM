using MediatR;

namespace FinCRM.ApplicationServices.API.Domain
{
    // Tu będziemy opisywać każdy z naszych requestów

    //IRequest pochodzi z zainstalowanego Medtiatr. 

    //Jako generyk jest przypisna jego odpowiedź. Odpoiwedzią na Request jest Response
    public class GetClientsRequest : IRequest<GetClientsResponse>
    {

    }
}
