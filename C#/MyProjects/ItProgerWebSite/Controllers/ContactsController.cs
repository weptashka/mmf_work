using Microsoft.AspNetCore.Mvc;

namespace ItProgerWebSite.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index() //contacts
        {
            return View();
        }
    }
}
