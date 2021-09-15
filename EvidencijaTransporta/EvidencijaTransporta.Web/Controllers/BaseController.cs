using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.Web.Services;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class BaseController : Controller
	{
		public BaseController()
		{
			Repository = new Repository();
			TransportService = new TransportService(Repository);
			WarehouseService = new WarehouseService(Repository);
		}

		protected Repository Repository { get; }
		protected TransportService TransportService { get; }
		protected WarehouseService WarehouseService { get; set; }
	}
}