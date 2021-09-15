using EvidencijaTransporta.DataAccess.Attributes;

namespace EvidencijaTransporta.DataAccess.Models.ListAllWarehouses
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.LIST_ALL_WAREHOUSES)]
	public class ListAllWarehousesRequest : RequestModel<ListAllWarehousesRequest> { }
}
