using Microsoft.AspNetCore.Mvc;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class PrintingEditionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
