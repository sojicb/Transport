using EvidencijaTransporta.DataAccess.Models.GetTypesOfVehicles;
using System.ComponentModel.DataAnnotations;

namespace EvidencijaTransporta.Web.Models
{
	public class VehicleTypeModel
	{
		public VehicleTypeModel(GetTypesOfVehiclesResponse response)
		{
			Id = response.Id;
			VehicleType = response.VehicleType;
			TransportTypeId = response.TransportTypeId;
		}

		public int Id { get; set; }

		[Display(Name = "Vehicle Type")]
		public string VehicleType { get; set; }

		public int TransportTypeId { get; set; }
	}
}