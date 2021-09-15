using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.UpdateTransportReservation
{
	public class UpdateTransportReservationResponse : IResponseModel
	{
		public int Id { get; set; }

		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new UpdateTransportReservationResponse
			{
				Id = (int)reader["Id"]
			};
		}
	}
}
