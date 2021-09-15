using EvidencijaTransporta.Web.Models;
using EvidencijaTransporta.Web.Models.ViewModels.Pages;
using System.Linq;
using System.Web.Mvc;

namespace EvidencijaTransporta.Web.Controllers
{
	public class TransportController : BaseController
    {
        /// <summary>
        /// Lists all Transport reservations
        /// </summary>
        /// <returns>View with all Transport Reservations</returns>
        public ActionResult Index()
        {
            return View(new TransportViewModel(TransportService.ListTransportsService()));
        }

        [ChildActionOnly]
        public ActionResult ReservateTransport(CreateTransportModel model = null)
        {
            return PartialView(CreateReservateTransportViewModel());
        }

        public ActionResult ListTransportReservations()
        {
            return PartialView("TransportTable", new TransportViewModel(TransportService.ListTransportsService()));
        }


        /// <summary>
        /// Method that creates a new model of ReservateTransport
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// //TODO FIX ON EMPTY MODEL
		[HttpPost]
		public ActionResult CreateReservateTransport(CreateTransportJsonModel model)
		{
            if (ModelState.IsValid)
			{
                TransportService.ReservateTransportService(model);

                return RedirectToAction("ListTransportReservations");
            }

			return PartialView(CreateReservateTransportViewModel());
		}

		public ActionResult FillEditTransport(int id)
		{
			TransportModel transportModel = TransportService.ListTransportsService().Where(x => x.Id == id).FirstOrDefault();

            CreateTransportModel model =  new CreateTransportModel
            {
                Id = transportModel.Id,
                ShipmentAmount = transportModel.ShipmentAmount,
                Date = transportModel.Date,
                SelectedTransportType = transportModel.TransportTypeId,
                VehicleType = transportModel.VehicleType
            };

            return PartialView("ReservateTransport", CreateReservateTransportViewModel(model));
		}

        public ActionResult EditTransport(CreateTransportModel model)
		{
            if (ModelState.IsValid)
            {
                TransportService.UpdateTransportReservationService(model);

                return RedirectToAction("ListTransportReservations");
            }

            return View(CreateReservateTransportViewModel(model));

		}

		[HttpGet]
        public ActionResult Details(int id)
        {
            TransportModel model = TransportService.ListTransportsService().Where(x => x.Id == id).FirstOrDefault();

            return PartialView(model);
        }

        public ActionResult Delete(int id)
		{
            TransportService.RemoveTransportReservationService(id);

            return RedirectToAction("ListTransportreservations");
        }

        private CreateTransportModel CreateReservateTransportViewModel(CreateTransportModel model = null)
        {
            CreateTransportModel createTransportModel = new CreateTransportModel();

			if (ModelState.IsValid)
			{
                createTransportModel.Id = model.Id;
                createTransportModel.SelectedTransportType = model.SelectedTransportType;
                createTransportModel.Date = model.Date;
                createTransportModel.ShipmentAmount = model.ShipmentAmount;
                createTransportModel.VehicleType = model.VehicleType;
            }

            createTransportModel.TransportTypes = TransportService.GetAllTransportTypesService().Select(transport => new SelectListItem
            {
                Text = transport.TransportType,
                Value = transport.Id.ToString()
            });

            createTransportModel.VehicleTypes = TransportService.GetVehiclesService(3).Select(vehicle => new SelectListItem
            {
                Text = vehicle.VehicleType,
                Value = vehicle.Id.ToString()
            });

            return createTransportModel;
        }
    }
}