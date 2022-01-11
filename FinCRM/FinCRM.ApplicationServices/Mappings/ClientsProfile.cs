namespace FinCRM.ApplicationServices.Mappings
{
    using AutoMapper;
    using FinCRM.ApplicationServices.API.Domain;
    using System.Collections.Generic;
    using System.Linq;


    //Klasa po której dziedziczymy - Profile - pochodzi z AutoMappera
    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            // definicja mapy - CreateMap - jest z AutoMappera.
            //Chcemy mapować model z encji na model
            this.CreateMap<DataAccess.Entities.Client, FinCRM.ApplicationServices.API.Domain.Models.Clients>()

                // GET CLIENTS
                //teraz dla bezpieczeństwa, dla każdej jednej propercji zrobimy mapowanie.
                //AutoMapper mógłby zrobić to sam i po prostu wszystkie brać zawsze, ale gdyby ktoś zmienił nazwę jednego property, to już się AutoMapper rozjedzie.
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Source, y => y.MapFrom(z => z.Source))
                .ForMember(x => x.SneakPeak, y => y.MapFrom(z => z.SneakPeak))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                ;

            // GET CLIENT BY ID
            this.CreateMap<DataAccess.Entities.Client, FinCRM.ApplicationServices.API.Domain.Models.Client>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Source, y => y.MapFrom(z => z.Source))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.SneakPeak, y => y.MapFrom(z => z.SneakPeak))
                .ForMember(x => x.CorrespondenceAddress, y => y.MapFrom(z => z.CorrespondenceAddress))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                .ForMember(x => x.Applications, y => y.MapFrom(z => z.Applications != null ? z.Applications.Select(x => x.Goal) : new List<string>()))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                ;

            //POST CLIENT
            // Tu chcemy mapować z AddClientRequest na encję Client, przy dodawaniu Klienta
            this.CreateMap<AddClientRequest, DataAccess.Entities.Client>()
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Source, y => y.MapFrom(z => z.Source))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.SneakPeak, y => y.MapFrom(z => z.SneakPeak))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                .ForMember(x => x.CorrespondenceAddress, y => y.MapFrom(z => z.CorrespondenceAddress))
                ;


            //DELETE CLIENT
            this.CreateMap<DeleteClientByIdRequest, DataAccess.Entities.Client>()
                 .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                ;


            //PUT CLIENT
            this.CreateMap<UpdateClientByIdRequest, DataAccess.Entities.Client>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Source, y => y.MapFrom(z => z.Source))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.SneakPeak, y => y.MapFrom(z => z.SneakPeak))
                .ForMember(x => x.CorrespondenceAddress, y => y.MapFrom(z => z.CorrespondenceAddress))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                ;

        }
    }
}