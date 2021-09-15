using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using System;
using System.ComponentModel.DataAnnotations;

namespace EvidencijaTransporta.Web.Models
{
	public class TransportModel
	{
		public TransportModel(ResponseAllTransports response)
		{
			Id = response.Id;
			Date = response.Date;
			VehicleType = response.TypeOfVehicle;
			TransportTypeId = response.TransportTypeId;
			ShipmentAmount = response.ShipmentAmount;
			TransportType = response.TypeOfTransport;
		}

		public int Id { get; set; }

		[Display(Name = "Date")]
		public DateTime Date { get; set; }

		[Display(Name = "Transport Type")]
		public string TransportType { get; set; }

		[Display(Name = "Shipment Amount")]
		public string ShipmentAmount { get; set; }

		[Display(Name = "Vehicle Type")]
		public string VehicleType { get; set; }

		public int TransportTypeId { get; set; }
	}
}