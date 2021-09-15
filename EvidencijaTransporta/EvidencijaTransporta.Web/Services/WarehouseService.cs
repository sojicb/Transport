using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.GetStorageInformation;
using EvidencijaTransporta.DataAccess.Models.InsertStorageInformation;
using EvidencijaTransporta.DataAccess.Models.ListAllWarehouses;
using EvidencijaTransporta.Web.Models.WarehouseModels;
using System.Collections.Generic;
using System.Linq;

namespace EvidencijaTransporta.Web.Services
{
	public class WarehouseService : BaseService
	{
		public WarehouseService(Repository repository) : base(repository) { }

		/// <summary>
		/// Gets a list of all warehouses from the database
		/// </summary>
		/// <returns>All warehouse responses converted into WarehouseModel</returns>
		public List<WarehouseModel> ListWarehousesService()
		{
			List<ListAllWarehousesResponse> response = _repository.
				GetListStoredProcedure<ListAllWarehousesResponse, ListAllWarehousesRequest>(new ListAllWarehousesRequest());

			return response?.Select(warehouse => new WarehouseModel(warehouse)).ToList() 
				?? Enumerable.Empty<WarehouseModel>().ToList();
		}

		public StorageModel PrepareModel(int id)
		{
			return new StorageModel
			{
				WarehouseId = id
			};
		}

		public void InsertStorageInformationService(StorageModel model)
		{
			var request = _mapper.Map<InsertStorageInformationRequest>(model);

				_repository.
			ExecuteProcedureWithParameters<InsertStorageInformationRequest, InsertStorageInformationResponse>(request);
		}

		/// <summary>
		/// Gets all storage information for a given warehouse
		/// </summary>
		/// <param name="id">warehouse id</param>
		/// <returns>List of all information or epmty list if there is no rows in the database</returns>
		public List<StorageModel> GetStorageInformationForWarehouseService(int id)
		{
			GetStorageInformationRequest request = new GetStorageInformationRequest
			{
				Id = id
			};

			List<GetStorageInformationResponse> response = _repository.
				GetListStoredProcedureWithParameters<GetStorageInformationResponse, GetStorageInformationRequest>(request);

			return response?.Select(information => new StorageModel(information)).ToList()
				?? Enumerable.Empty<StorageModel>().ToList();
		}
	}
}