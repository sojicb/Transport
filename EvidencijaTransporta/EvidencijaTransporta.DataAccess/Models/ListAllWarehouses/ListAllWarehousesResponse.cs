using EvidencijaTransporta.DataAccess.Attributes;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.ListAllWarehouses
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_WAREHOUSES)]
	public class ListAllWarehousesResponse : IResponseModel
	{
		[DataBeseResponseParameterName("Id")]
		public int Id { get; set; }

		[DataBeseResponseParameterName("Name")]
		public string Name { get; set; }

		[DataBeseResponseParameterName("CurrentCapacity")]
		public int CurrentCapacity { get; set; }

		[DataBeseResponseParameterName("MaximumCapacity")]
		public int MaximumCapacity { get; set; }

		[DataBeseResponseParameterName("City")]
		public string City { get; set; }

		[DataBeseResponseParameterName("Country")]
		public string Country { get; set; }

		[DataBeseResponseParameterName("StreetAndNumber")]
		public string StreetAndNumber { get; set; }


		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new ListAllWarehousesResponse
			{
				Id = (int)reader["Id"],
				Name = reader["Name"] as string,
				CurrentCapacity = (int)reader["CurrentCapacity"],
				MaximumCapacity = (int)reader["MaximumCapacity"],
				City = reader["City"] as string,
				Country = reader["Country"] as string,
				StreetAndNumber = reader["StreetAndNumber"] as string,
			};
		}
	}
}
