using EvidencijaTransporta.DataAccess.Attributes;
using System.Data;

namespace EvidencijaTransporta.DataAccess.Models.GetStorageInformation
{
	[DataBaseProcedureName(Constants.DataBaseProcedureNames.GET_STORAGE_INFORMATION)]
	public class GetStorageInformationRequest : RequestModel<GetStorageInformationRequest>
	{
		[DataBaseRequestParameterName("Id", SqlDbType.Int)]
		public int Id { get; set; }
	}
}
