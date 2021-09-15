using EvidencijaTransporta.DataAccess.Attributes;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.GetTypesOfVehicles
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.GET_TYPES_OF_VEHICLE)]
	public class GetTypesOfVehiclesResponse : IResponseModel
	{
		[DataBeseResponseParameterName("Id")]
		public int Id { get; set; }

		[DataBeseResponseParameterName("VehicleType")]
		public string VehicleType { get; set; }

		[DataBeseResponseParameterName("TransportTypeId")]
		public int TransportTypeId { get; set; }

		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new GetTypesOfVehiclesResponse
			{
				Id = (int)reader["Id"],
				TransportTypeId = (int)reader["TransportTypeId"],
				VehicleType = reader["VehicleType"] as string
			};
		}
	}
}
