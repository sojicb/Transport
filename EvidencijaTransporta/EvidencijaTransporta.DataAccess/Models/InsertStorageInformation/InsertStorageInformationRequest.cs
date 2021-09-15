using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Data;

namespace EvidencijaTransporta.DataAccess.Models.InsertStorageInformation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.INSERT_STORAGE_INFORMATION)]
	public class InsertStorageInformationRequest : RequestModel<InsertStorageInformationRequest>
	{
		[DataBaseRequestParameterName("Amount", SqlDbType.Int)]
		public int Amount { get; set; }

		[DataBaseRequestParameterName("Type", SqlDbType.NVarChar)]
		public string Type { get; set; }

		[DataBaseRequestParameterName("DateStored", SqlDbType.Date)]
		public DateTime DateStored { get; set; }

		[DataBaseRequestParameterName("DateCleared", SqlDbType.Date)]
		public DateTime DateCleared { get; set; }

		[DataBaseRequestParameterName("WarehouseId", SqlDbType.Int)]
		public int WarehouseId { get; set; }
	}
}
