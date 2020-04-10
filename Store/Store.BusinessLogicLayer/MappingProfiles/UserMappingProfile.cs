using AutoMapper;
using Store.BusinessLogicLayer.Models.Users;
using Store.DataAccessLayer.Entities;

namespace Store.BusinessLogicLayer.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>().ForMember(x => x.UserName, option => option.MapFrom<NameResolver>());
        }
    }

    internal class NameResolver : IValueResolver<UserModel, User, string>
    {
        public string Resolve(UserModel source, User destination, string destMember, ResolutionContext context)
        {
            return $"{source.FirstName}_{source.LastName}";
        }
    }
}
