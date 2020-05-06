using Microsoft.AspNetCore.Mvc;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
using Stripe;
using System.IO;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route(Constant.Routes.DEFAULT_API_ROUTE)]
    public class StripeWebHookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                //TODO EE: create email notification/push notification
                var stripeEvent = EventUtility.ParseEvent(json);
                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

                }
            }
            catch (System.Exception ex)
            {

                throw new UserException(ex.Message, Enums.ErrorCode.BadRequest);
            }

            return Ok();
        }
    }
}
