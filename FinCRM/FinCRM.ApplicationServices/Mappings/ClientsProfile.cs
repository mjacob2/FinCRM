namespace FinCRM.ApplicationServices.Mappings
{
    using AutoMapper;
    using FinCRM.ApplicationServices.API.Domain;
    using System.Collections.Generic;
    using System.Linq;


    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            this.CreateMap<DataAccess.Entities.Client, FinCRM.ApplicationServices.API.Domain.Models.Clients>()

                // GET CLIENTS
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Source, y => y.MapFrom(z => z.Source))
                .ForMember(x => x.Stage, y => y.MapFrom(z => z.Stage))
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
                .ForMember(x => x.Stage, y => y.MapFrom(z => z.Stage))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.SneakPeak, y => y.MapFrom(z => z.SneakPeak))
                .ForMember(x => x.CorrespondenceAddress, y => y.MapFrom(z => z.CorrespondenceAddress))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                .ForMember(x => x.Applications, y => y.MapFrom(z => z.Applications != null ? z.Applications.Select(x => x.Goal) : new List<string>()))
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                ;

            //POST CLIENT
            this.CreateMap<AddClientRequest, DataAccess.Entities.Client>()
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Source, y => y.MapFrom(z => z.Source))
                .ForMember(x => x.Stage, y => y.MapFrom(z => z.Stage))
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
                .ForMember(x => x.Stage, y => y.MapFrom(z => z.Stage))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.SneakPeak, y => y.MapFrom(z => z.SneakPeak))
                .ForMember(x => x.CorrespondenceAddress, y => y.MapFrom(z => z.CorrespondenceAddress))
                .ForMember(x => x.Note, y => y.MapFrom(z => z.Note))
                ;

        }
    }
}