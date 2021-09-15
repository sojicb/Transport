using EvidencijaTransporta.Web.Models.ViewModels.Pages;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			return View(new HomeViewModel());
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		//TODO make one controller for one page

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}