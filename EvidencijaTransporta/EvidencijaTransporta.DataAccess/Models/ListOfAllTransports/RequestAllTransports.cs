using EvidencijaTransporta.DataAccess.Attributes;

namespace EvidencijaTransporta.DataAccess.Models.ListOfAllTransports
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_TRANSPORTS)]
	public class RequestAllTransports : RequestModel<RequestAllTransports> { }
}
