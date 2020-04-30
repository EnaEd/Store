using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class PrintingEditionController : Controller
    {
        private readonly IPrintingEditionService _printingEditionService;

        public PrintingEditionController(IPrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        [HttpGet("getedition")]
        public async Task<IActionResult> GetEdition()
        {
            return Ok(await _printingEditionService.GetPrintingEdition());
        }
    }
}
