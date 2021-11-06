using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using FinCRM.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Handlers
{
    public class GetApplicationsHandler : IRequestHandler<GetApplicationsRequest, GetApplicationsResponse>
    {

        private readonly IRepository<Application> ApplicationRepository;
        public GetApplicationsHandler(IRepository<DataAccess.Entities.Application> ApplicationRepository)
        {
            this.ApplicationRepository = ApplicationRepository;
        }


        public Task<GetApplicationsResponse> Handle(GetApplicationsRequest request, CancellationToken cancellationToken)
        {
            var Applications = this.ApplicationRepository.GetAll();

            var domainApplications = Applications.Select(x => new Domain.Models.Application()
            {
                // Tu obsługujemy wszystkie dane, które zawarliśmy w modelu
                Id = x.Id,
                Type = x.Type,
                Bank = x.Bank,
                LoanAmount = x.LoanAmount,
                CommissionAmount = x.CommissionAmount,
                DateOfCreation = x.DateOfCreation,
                Age = x.Age,
                Note = x.Note,


            });

            var response = new GetApplicationsResponse()
            {
                Data = domainApplications.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
