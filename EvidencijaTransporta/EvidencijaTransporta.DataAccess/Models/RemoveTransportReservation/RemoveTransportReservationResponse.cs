using EvidencijaTransporta.DataAccess.Attributes;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.RemoveTransportReservation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.REMOVE_TRANSPORT_RESERVATION)]
	public class RemoveTransportReservationResponse : IResponseModel
	{
		public int Id { get; set; }

		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new RemoveTransportReservationResponse
			{
				Id = (int)reader["Id"]
			};
		}
	}
}
