using System;
using System.ComponentModel.DataAnnotations;

namespace EvidencijaTransporta.Web.Models
{
	public class CreateTransportJsonModel
	{
		[Required]
		[Display(Name = "Date")]
		public DateTime Date { get; set; }

		[Required]
		[Display(Name = "Transport Type")]
		public int SelectedTransportType { get; set; }

		[Required]
		[Display(Name = "Shipment Amount")]
		public string ShipmentAmount { get; set; }

		[Required]
		[Display(Name = "Vehicle Type")]
		public string VehicleType { get; set; }
	}
}