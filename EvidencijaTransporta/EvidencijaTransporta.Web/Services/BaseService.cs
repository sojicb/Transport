using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.Web.Mapping;

namespace EvidencijaTransporta.Web.Services
{
	public class BaseService : WarehouseMapperProfile
	{
		protected Repository _repository { get; set; }

		public BaseService(Repository repository)
		{
			_repository = repository;
		}
	}
}