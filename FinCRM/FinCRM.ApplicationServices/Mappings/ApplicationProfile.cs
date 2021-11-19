namespace FinCRM.ApplicationServices.Mappings
{
    using AutoMapper;
    using FinCRM.ApplicationServices.API.Domain;
    using System.Collections.Generic;
    using System.Linq;

    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            // definicja mapy - CreateMap - jest z AutoMappera.
            //Chcemy mapować model z encji na model
            this.CreateMap<DataAccess.Entities.Application, FinCRM.ApplicationServices.API.Domain.Models.Application>()

                //teraz dla bezpieczeństwa, dla każdej jednej propercji zrobimy mapowanie.
                //Auto-mapper mógłby zrobić to sam i po prostu wszystkie brać zawsze, ale gdyby ktoś zmienił nazwę jednego property, to już się automapper rozjedzie.
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Bank, y => y.MapFrom(z => z.Bank))
                .ForMember(x => x.LoanAmount, y => y.MapFrom(z => z.LoanAmount))
                .ForMember(x => x.CommissionAmount, y => y.MapFrom(z => z.CommissionAmount))
                .ForMember(x => x.DateOfCreation, y => y.MapFrom(z => z.DateOfCreation))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                .ForMember(x => x.ClientsNames, y => y.MapFrom(z => z.Clients != null ? z.Clients.Select(x => x.FirstName) : new List<string>()));


            // Tu chcemy mapować z AddApplicationRequest na encję Application, przy dodawaniu Aplikacji
            this.CreateMap<AddApplicationRequest, DataAccess.Entities.Application >()
                
                .ForMember(x => x.Bank, y => y.MapFrom(z => z.Bank))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.LoanAmount, y => y.MapFrom(z => z.LoanAmount));
        }
    }
}
