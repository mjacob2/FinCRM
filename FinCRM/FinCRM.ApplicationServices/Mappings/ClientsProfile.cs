namespace FinCRM.ApplicationServices.Mappings
{ 
    using AutoMapper;


    //Klasa po któej dziedziczymy - Profile - pochodzi z AutoMappera
   public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            // definicja mapy - CreateMap - jest z AutoMappera.
            //Chcemy mapować model z encji na model
            this.CreateMap<DataAccess.Entities.Client, FinCRM.ApplicationServices.API.Domain.Models.Client>()

                //teraz dla nbezpieczeństwa, dla każdej jednej propercji zrobimy mapowanie.
                //Automapper mógłby zrobić to sam i po prostu wszystkie brać zawsze, ale gdyby ktoś zmienił nazwę jednego property, to już się automapper rozjedzie.
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Source, y => y.MapFrom(z => z.Source))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.DateOfCreation, y => y.MapFrom(z => z.DateOfCreation))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note));
        }
    }
}
