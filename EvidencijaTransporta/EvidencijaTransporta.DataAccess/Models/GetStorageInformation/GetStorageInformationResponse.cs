using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.GetStorageInformation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.GET_STORAGE_INFORMATION)]
	public class GetStorageInformationResponse : IResponseModel
	{
		[DataBeseResponseParameterName("Id")]
		public int Id { get; set; }

		[DataBeseResponseParameterName("Amount")]
		public int Amount { get; set; }

		[DataBeseResponseParameterName("Type")]
		public string Type { get; set; }

		[DataBeseResponseParameterName("DateStored")]
		public DateTime DateStored { get; set; }

		[DataBeseResponseParameterName("DateCleared")]
		public DateTime DateCleared { get; set; }

		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new GetStorageInformationResponse
			{
				Id = (int)reader["Id"],
				Amount = (int)reader["Amount"],
				Type = reader["Type"] as string,
				DateStored = (DateTime)reader["DateStored"],
				DateCleared = (DateTime)reader["DateCleared"],
			};
		}
	}
}
