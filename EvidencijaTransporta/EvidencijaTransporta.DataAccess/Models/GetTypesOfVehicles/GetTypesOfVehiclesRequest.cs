using EvidencijaTransporta.DataAccess.Attributes;
using System.Data;

namespace EvidencijaTransporta.DataAccess.Models.GetTypesOfVehicles
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.GET_TYPES_OF_VEHICLE)]
	public class GetTypesOfVehiclesRequest : RequestModel<GetTypesOfVehiclesRequest>
	{
		[DataBaseRequestParameterName("Id", SqlDbType.Int)]
		public int TransportTypeId { get; set; }
	}
}
