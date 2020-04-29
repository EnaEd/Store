using AutoMapper;
using Store.BusinessLogicLayer.Models.Author;
using Store.DataAccessLayer.Entities;

namespace Store.BusinessLogicLayer.MappingProfiles
{
    class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, AuthorModel>();
            CreateMap<AuthorModel, Author>();
        }
    }
}
