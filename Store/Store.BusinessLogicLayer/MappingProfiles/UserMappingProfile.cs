using AutoMapper;
using Store.BusinessLogicLayer.Models.Users;
using Store.DataAccessLayer.Entities;
using Store.Shared.Enums;
using System;

namespace Store.BusinessLogicLayer.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>().ForMember(x => x.UserName, option => option.MapFrom<NameResolver>());
            CreateMap<UserFilterEntity, UserFilterModel>();
            CreateMap<UserFilterModel, UserFilterEntity>();
            CreateMap<UserProfileEntity, UserProfileModel>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(UserRole), src.Role)));
            CreateMap<UserProfileModel, UserProfileEntity>();
        }
    }

    internal class NameResolver : IValueResolver<UserModel, User, string>
    {
        public string Resolve(UserModel source, User destination, string destMember, ResolutionContext context)
        {
            return $"{source.Email}";
        }
    }
}
