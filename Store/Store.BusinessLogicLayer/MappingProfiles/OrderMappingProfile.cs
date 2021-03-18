using AutoMapper;
using Store.BusinessLogicLayer.Models.Order;
using Store.DataAccessLayer.Entities;

namespace Store.BusinessLogicLayer.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderItem, OrderItemRequestModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Order, OrderRequestModel>().ReverseMap();
        }
    }
}
