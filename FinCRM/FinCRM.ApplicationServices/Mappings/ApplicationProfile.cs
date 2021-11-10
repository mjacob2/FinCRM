namespace FinCRM.ApplicationServices.Mappings
{
    using AutoMapper;
    using FinCRM.ApplicationServices.API.Domain;

    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            // definicja mapy - CreateMap - jest z AutoMappera.
            //Chcemy mapować model z encji na model
            this.CreateMap<DataAccess.Entities.Application, FinCRM.ApplicationServices.API.Domain.Models.Application>()

                //teraz dla nbezpieczeństwa, dla każdej jednej propercji zrobimy mapowanie.
                //Automapper mógłby zrobić to sam i po prostu wszystkie brać zawsze, ale gdyby ktoś zmienił nazwę jednego property, to już się automapper rozjedzie.
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Bank, y => y.MapFrom(z => z.Bank))
                .ForMember(x => x.LoanAmount, y => y.MapFrom(z => z.LoanAmount))
                .ForMember(x => x.CommissionAmount, y => y.MapFrom(z => z.CommissionAmount))
                .ForMember(x => x.DateOfCreation, y => y.MapFrom(z => z.DateOfCreation))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note));


            // Tu chcemy mapować z AddApplicationRequest na encję Application, pzrzy dodawaniu Apliakcji
            this.CreateMap<AddApplicationRequest, DataAccess.Entities.Application >()
                
                .ForMember(x => x.Bank, y => y.MapFrom(z => z.Bank))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.LoanAmount, y => y.MapFrom(z => z.LoanAmount));
        }
    }
}
