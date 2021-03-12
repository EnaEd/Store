using AutoMapper;
using Store.BusinessLogicLayer.Models.Base;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.Models.Base;

namespace Store.BusinessLogicLayer.MappingProfiles
{
    public class PrintingEditionProfile : Profile
    {
        public PrintingEditionProfile()
        {
            CreateMap<PrintingEditionFilterModel, PrintingEditionFilterDTO>().ReverseMap();
            CreateMap<PrintingEditionModel, PrintingEdition>().ReverseMap();
            CreateMap<PrintingEdition, PrintingEditionProfileModel>().ReverseMap();

            CreateMap<PriceRangeModel, PriceRangeDTO>().ReverseMap();

        }
    }
}
