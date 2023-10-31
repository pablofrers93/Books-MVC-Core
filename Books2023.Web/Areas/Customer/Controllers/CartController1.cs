using Microsoft.AspNetCore.Mvc;

namespace Books2023.Web.Areas.Customer.Controllers
{
    public class CartController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
