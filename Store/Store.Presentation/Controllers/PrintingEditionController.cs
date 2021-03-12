using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.PrintingEdition;
using Store.Shared.Constants;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route(Constant.Routes.DEFAULT_API_ROUTE)]
    public class PrintingEditionController : Controller
    {
        private readonly IPrintingEditionService _printingEditionService;
        private readonly IStripeService _stripeService;

        public PrintingEditionController(IPrintingEditionService printingEditionService, IStripeService stripeService)
        {
            _printingEditionService = printingEditionService;
            _stripeService = stripeService;
        }

        [HttpPost(Constant.Routes.GET_EDITIONS_ROUTE)]
        public async Task<IActionResult> GetEditionAsync([FromBody] PrintingEditionFilterModel model)
        {
            var result = await _printingEditionService.GetPrintingEditionAsync(model);
            return Ok(result);
        }

        [HttpPost(Constant.Routes.CREATE_EDITION_ROUTE)]
        [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
        public async Task<IActionResult> CreateEditionAsync([FromBody] PrintingEditionRequestModel model)
        {
            await _printingEditionService.CreatePrintingEditionAsync(model);
            return Ok(Constant.Info.CREATE_EDITION_SUCCESS);
        }

        [HttpPost(Constant.Routes.DELETE_EDITION_ROUTE)]
        [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
        public async Task<IActionResult> DeleteEditionAsync([FromBody] PrintingEditionRequestModel model)
        {
            await _printingEditionService.DeletePrintingEditionAsync(model);
            return Ok(Constant.Info.REMOVE_EDITION_SUCCESS);
        }

        [HttpPost(Constant.Routes.UPDATE_EDITION_ROUTE)]
        [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
        public async Task<IActionResult> UpdateEditionAsync([FromBody] PrintingEditionRequestModel model)
        {
            await _printingEditionService.UpdatePrintingEditionAsync(model);
            return Ok(Constant.Info.UPDATE_EDITION_SUCCESS);
        }

        [HttpPost(Constant.Routes.PAY_EDITION_ROUTE)]
        public async Task<IActionResult> PayEditionAsync([FromBody] PayRequestModel model)
        {
            model.UserEmail = User.Identity.Name;
            return Ok(await _stripeService.PayAsync(model));
        }
    }
}
