using EvidencijaTransporta.Web.Models.ViewModels.Pages;
using EvidencijaTransporta.Web.Models.WarehouseModels;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class WarehouseController : BaseController
    {
		public ActionResult Index()
        {
            return View(new WarehouseViewModel(WarehouseService.ListWarehousesService()));
        }

        [HttpGet]
        public ActionResult OpenStoreItems(int Id)
		{
            return PartialView("OpenStoredItems", WarehouseService.GetStorageInformationForWarehouseService(Id));
		}

        public ActionResult ListWarehouses()
        {
            return PartialView("WarehouseTable", new WarehouseViewModel(WarehouseService.ListWarehousesService()));
        }

        public ActionResult RenderStorage(int id = 0)
		{
            return PartialView("RenderStorage", WarehouseService.PrepareModel(id));
		}

        [HttpPost]
        public ActionResult StoreInformation(StorageModel model = null)
		{
			if (ModelState.IsValid)
			{
                WarehouseService.InsertStorageInformationService(model);

                return RedirectToAction("ListWarehouses");
			}

            return PartialView("RenderStorage");
		}
    }
}