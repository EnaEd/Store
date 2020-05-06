using Microsoft.Extensions.Options;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Config;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class StripeService : IStripeService
    {
        private readonly IOptions<StripeConfig> _options;

        public StripeService(IOptions<StripeConfig> options)
        {
            _options = options;

        }

        public async Task<dynamic> PayAsync(PayRequestModel model)
        {
            try
            {
                var paymentMethodOptions = new PaymentMethodCreateOptions()
                {
                    Type = SourceType.Card,
                    Card = new PaymentMethodCardCreateOptions
                    {
                        Number = model.CardNumber,
                        Cvc = model.CVCCode,
                        ExpMonth = model.ExpMonth,
                        ExpYear = model.ExpYear
                    }
                };

                PaymentMethodService cardService = new PaymentMethodService();
                var card = await cardService.CreateAsync(paymentMethodOptions);

                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)model.Amount,
                    Currency = Enums.Currency.USD.ToString().ToLower(),
                    PaymentMethodTypes = new List<string> { _options.Value.DefaultPaymentTypes },
                    PaymentMethod = card.Id,
                    Confirm = true
                };

                var service = new PaymentIntentService();
                var intent = await service.CreateAsync(options);

                return Constant.Info.SUCCESS;
            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message, Enums.ErrorCode.BadRequest);
            }
        }

    }
}
