using EvidencijaTransporta.DataAccess.Models.ListAllTransportTypes;
using System.ComponentModel.DataAnnotations;

namespace EvidencijaTransporta.Web.Models
{
	public class TransportTypeModel
	{
		public TransportTypeModel(ListAllTransportTypesResponseModel listAllTransportTypes)
		{
			Id = listAllTransportTypes.Id;
			TransportType = listAllTransportTypes.TransportType;
		}

		public int Id { get; }

		[Display(Name = "Transport Type")]
		public string TransportType { get; }
	}
}