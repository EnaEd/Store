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

        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        [HttpGet(Constant.Routes.GET_EDITIONS_ROUTE)]
        public async Task<IActionResult> GetEdition()
        {
            return Ok(await _printingEditionService.GetPrintingEditionAsync());
        }

        [HttpPost(Constant.Routes.CREATE_EDITION_ROUTE)]
        [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
        public async Task<IActionResult> CreateEdition([FromBody]PrintingEditionProfileModel model)
        {
            await _printingEditionService.CreatePrintingEditionAsync(model);
            return Ok(Constant.Info.CREATE_EDITION_SUCCESS);
        }

        [HttpPost(Constant.Routes.DELETE_EDITION_ROUTE)]
        [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
        public async Task<IActionResult> DeleteEdition([FromBody]PrintingEditionProfileModel model)
        {
            await _printingEditionService.DeletePrintingEditionAsync(model);
            return Ok(Constant.Info.REMOVE_EDITION_SUCCESS);
        }

        [HttpPost(Constant.Routes.UPDATE_EDITION_ROUTE)]
        [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
        public async Task<IActionResult> UpdateEdition([FromBody]PrintingEditionProfileModel model)
        {
            await _printingEditionService.UpdatePrintingEditionAsync(model);
            return Ok(Constant.Info.UPDATE_EDITION_SUCCESS);
        }
    }
}
