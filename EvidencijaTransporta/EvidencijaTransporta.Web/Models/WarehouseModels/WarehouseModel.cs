using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EvidencijaTransporta.DataAccess.Models.ListAllWarehouses;

namespace EvidencijaTransporta.Web.Models.WarehouseModels
{
	public class WarehouseModel
	{
		public WarehouseModel(ListAllWarehousesResponse response)
		{
			Id = response.Id;
			Name = response.Name;
			CurrentCapacity = response.CurrentCapacity;
			MaximumCapacity = response.MaximumCapacity;
			City = response.City;
			Country = response.Country;
			StreetAndNumber = response.StreetAndNumber;
		}

		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Current Capacity in tones")]
		public int CurrentCapacity { get; set; }

		[Display(Name = "Maximum Capacity in tones")]
		public int MaximumCapacity { get; set; }

		[Display(Name = "City")]
		public string City { get; set; }

		[Display(Name = "Country")]
		public string Country { get; set; }

		[Display(Name = "Street And Number")]
		public string StreetAndNumber { get; set; }

		public IList<StorageModel> StorageInformation { get; set; }
	}
}