using System;

namespace EvidencijaTransporta.Web.Models.WarehouseModels
{
	public class JsonStorageModel
	{
		public int Amount { get; set; }
		public string Type { get; set; }
		public DateTime DateStored { get; set; }
		public DateTime DateCleared { get; set; }
		public int WarehouseId { get; set; }
	}
}