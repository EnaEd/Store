using AutoMapper;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;

namespace Store.BusinessLogicLayer.MappingProfiles
{
    public class PrintingEditionProfile : Profile
    {
        public PrintingEditionProfile()
        {
            CreateMap<PrintingEditionFilterModel, PrintingEditionFilterModelDAL>();
            CreateMap<PrintingEditionFilterModelDAL, PrintingEditionFilterModel>();
            CreateMap<PrintingEditionModel, PrintingEdition>();
            CreateMap<PrintingEdition, PrintingEditionModel>();
            CreateMap<PrintingEdition, PrintingEditionProfileModel>();
            CreateMap<PrintingEditionProfileModel, PrintingEdition>();
        }
    }
}
