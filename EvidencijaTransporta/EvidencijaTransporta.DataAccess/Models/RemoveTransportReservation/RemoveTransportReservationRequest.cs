using EvidencijaTransporta.DataAccess.Attributes;
using System.Data;

namespace EvidencijaTransporta.DataAccess.Models.RemoveTransportReservation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.REMOVE_TRANSPORT_RESERVATION)]
	public class RemoveTransportReservationRequest : RequestModel<RemoveTransportReservationRequest>
	{
		[DataBaseRequestParameterName("Id", SqlDbType.Int)]
		public int Id { get; set; }
	}
}
