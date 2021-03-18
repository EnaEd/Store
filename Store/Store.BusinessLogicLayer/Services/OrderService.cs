using AutoMapper;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Order;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using Store.Shared.Common;
using Store.Shared.Providers.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Store.Shared.Enums.Enums;

namespace Store.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository<Order> _orderRepository;
        private readonly IOrderItemRepository<OrderItem> _orderItemRepository;
        private readonly IValidationProvider _validationProvider;
        private readonly IMapper _mapper;
        private readonly IPaymentRepository<Payment> _paymentRepository;

        public OrderService(IOrderRepository<Order> orderRepository, IValidationProvider validationProvider, IMapper mapper, IOrderItemRepository<OrderItem> orderItemRepository, IPaymentRepository<Payment> paymentRepository)
        {
            _orderRepository = orderRepository;
            _validationProvider = validationProvider;
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<string> CreateAndBuyOrderAsync(OrderRequestModel model, Guid userId)
        {
            if (!_validationProvider.TryValidate(model, out List<string> errors))
            {
                throw new UserException(errors, ErrorCode.BadRequest);
            }
            //TODO EE: add validation amount

            var mappedOrder = _mapper.Map<Order>(model);
            mappedOrder.UserId = userId;
            var mappedOrderItem = mappedOrder.OrderItems;

            var options = new Stripe.ChargeCreateOptions
            {
                Amount = (long)mappedOrder.OrderItems.Sum(x => x.Amount) * 1000,
                Currency = "usd",
                Source = "tok_amex",
                Description = "Test Charge edena store(created for API docs)",
            };
            var service = new Stripe.ChargeService();
            var result = service.Create(options);


            mappedOrder.PayStatus = result.Paid ? PayStatus.Paid : PayStatus.Unpaid;

            var payment = new Payment() { TransactionId = result.OrderId };
            await _paymentRepository.CreateAsync(payment);

            await _orderRepository.CreateAsync(mappedOrder);
            await _orderItemRepository.CreateRangeAsync(mappedOrderItem);

            return mappedOrder.PayStatus.ToString();
        }

        public async Task CreateOrderAsync(OrderRequestModel model, Guid userId)
        {
            if (!_validationProvider.TryValidate(model, out List<string> errors))
            {
                throw new UserException(errors, ErrorCode.BadRequest);
            }
            //TODO EE:add logic for adding order without buy
            throw new NotImplementedException();
        }


    }
}
