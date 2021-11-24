﻿using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;


namespace FinCRM.ApplicationServices.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<DataAccess.Entities.User, FinCRM.ApplicationServices.API.Domain.Models.User>()

                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.Salt, y => y.MapFrom(z => z.Salt))
                ;

            // Tu chcemy mapować z AddUserRequest na encję User, przy dodawaniu usera
            this.CreateMap<AddUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
                .ForMember(x => x.Salt, y => y.MapFrom(z => z.Salt))
                ;

        }
    }
}
