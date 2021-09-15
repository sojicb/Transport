using EvidencijaTransporta.DataAccess.Attributes;
using System.Data.SqlClient;

namespace EvidencijaTransporta.DataAccess.Models.CreateReservation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.RESERVATE_TRANSPORT)]
	public class CreateReservationResponseModel : IResponseModel
	{
		public int Id { get; set; }

		public IResponseModel MapToObject(SqlDataReader reader)
		{
			return new CreateReservationResponseModel
			{
				Id = (int)reader["Id"]
			};
		}
	}
}
