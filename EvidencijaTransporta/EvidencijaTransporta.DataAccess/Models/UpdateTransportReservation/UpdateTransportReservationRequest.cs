using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Data;

namespace EvidencijaTransporta.DataAccess.Models.UpdateTransportReservation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.UPDATE_TRANSPORT_RESERVATION)]
	public class UpdateTransportReservationRequest : RequestModel<UpdateTransportReservationRequest>
	{
		[DataBaseRequestParameterName("Id", SqlDbType.Int)]
		public int Id { get; set; }

		[DataBaseRequestParameterName("Datum", SqlDbType.Date)]
		public DateTime Date { get; set; }

		[DataBaseRequestParameterName("KolicinaTransportneRobe", SqlDbType.NVarChar)]
		public string ShipmentAmount { get; set; }

		[DataBaseRequestParameterName("VrstaVozila", SqlDbType.NVarChar)]
		public string TypeOfVehicle { get; set; }

		[DataBaseRequestParameterName("VrstaTransportaId", SqlDbType.Int)]
		public int TypeOfTransport { get; set; }
	}
}
