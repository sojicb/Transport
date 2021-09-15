using EvidencijaTransporta.DataAccess.Attributes;
using System;
using System.Data;

namespace EvidencijaTransporta.DataAccess.Models.CreateReservation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.RESERVATE_TRANSPORT)]
	public class CreateResevationRequestModel : RequestModel<CreateResevationRequestModel>
	{
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
