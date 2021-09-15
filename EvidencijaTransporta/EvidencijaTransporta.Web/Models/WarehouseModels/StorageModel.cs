using EvidencijaTransporta.DataAccess.Models.GetStorageInformation;
using System;
using System.ComponentModel.DataAnnotations;

namespace EvidencijaTransporta.Web.Models.WarehouseModels
{
	public class StorageModel
	{
		public StorageModel()
		{

		}

		public StorageModel(GetStorageInformationResponse response)
		{
			Id = response.Id;
			Amount = response.Amount;
			Type = response.Type;
			DateStored = response.DateStored;
			DateCleared = response.DateCleared;
		}

		public int Id { get; set; }

		[Display(Name = "Amount in tones")]
		public int Amount { get; set; }

		[Display(Name = "Type of stored material")]
		public string Type { get; set; }

		[Display(Name = "Date from")]
		public DateTime DateStored { get; set; }

		[Display(Name = "Date to")]
		public DateTime DateCleared { get; set; }
		public int WarehouseId { get; set; }
	}
}