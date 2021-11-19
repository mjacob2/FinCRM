using AutoMapper;

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
                                .ForMember(x => x.Segment, y => y.MapFrom(z => z.Segment));
        }
    }
}
