using EvidencijaTransporta.Web.Models.ViewModels.Pages;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View(new ContactViewModel());
        }
    }
}