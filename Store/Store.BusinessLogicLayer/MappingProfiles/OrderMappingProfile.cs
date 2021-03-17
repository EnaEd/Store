using AutoMapper;
using Store.BusinessLogicLayer.Models.Order;
using Store.DataAccessLayer.Entities;

namespace Store.BusinessLogicLayer.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<Order, OrderRequestModel>().ReverseMap();
            CreateMap<OrderItem, OrderItemRequestModel>().ReverseMap();
        }
    }
}
