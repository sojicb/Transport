using EvidencijaTransporta.Web.Models.WarehouseModels;
using System.Collections.Generic;
using System.Linq;

namespace EvidencijaTransporta.Web.Models.ViewModels.Pages
{
	public class WarehouseViewModel : BaseViewModel
	{
		public WarehouseViewModel(IEnumerable<WarehouseModel> warehouses)
		{
			Title = "Warehouses";
			Warehouses = warehouses.ToList();
		}

		public IList<WarehouseModel> Warehouses { get; set; }
		public IList<StorageModel> Storage { get; set; }
	}
}