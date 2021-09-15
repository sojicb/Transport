using EvidencijaTransporta.Web.Models.ViewModels.Pages;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class AboutController : BaseController
    {
        // GET: About
        public ActionResult Index()
        {
            return View(new AboutViewModel());
        }
    }
}