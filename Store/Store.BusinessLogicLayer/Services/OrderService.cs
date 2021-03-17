using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Order;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Providers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Store.Shared.Enums.Enums;

namespace Store.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository<Order> _orderRepository;
        private readonly IValidationProvider _validationProvider;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository<Order> orderRepository, IValidationProvider validationProvider, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _validationProvider = validationProvider;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(OrderModel model)
        {
            if (!_validationProvider.TryValidate(model, out List<string> errors))
            {
                throw new UserException(errors, ErrorCode.BadRequest);
            }
            var entity = await _orderRepository.GetOneAsync(model.Id);
            if (entity is not null)
            {
                throw new UserException(Constant.Errors.ENTITY_ALREADY_EXISTS, ErrorCode.BadRequest);
            }
            var mappedItem = _mapper.Map<Order>(model);
            await _orderRepository.CreateAsync(mappedItem);
        }
    }
}
