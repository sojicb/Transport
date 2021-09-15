using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.CreateReservation;
using EvidencijaTransporta.DataAccess.Models.GetTypesOfVehicles;
using EvidencijaTransporta.DataAccess.Models.ListAllTransportTypes;
using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using EvidencijaTransporta.DataAccess.Models.RemoveTransportReservation;
using EvidencijaTransporta.DataAccess.Models.UpdateTransportReservation;
using EvidencijaTransporta.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace EvidencijaTransporta.Web.Services
{
	public class TransportService : BaseService
	{
		public TransportService(Repository repository) : base(repository) { }

		/// <summary>
		/// Gets a list of all transport types from the database
		/// </summary>
		/// <returns>All transportTypes converted into TransportTypeModel</returns>
		public List<TransportTypeModel> GetAllTransportTypesService()
        {
            ListAllTransportTypesRequestModel request = new ListAllTransportTypesRequestModel();

            List<ListAllTransportTypesResponseModel> responseModels = _repository.
                GetListStoredProcedure<ListAllTransportTypesResponseModel, ListAllTransportTypesRequestModel>(request);

            return responseModels?.Select(m => new TransportTypeModel(m)).ToList()
				?? Enumerable.Empty<TransportTypeModel>().ToList();
        }

		public void RemoveTransportReservationService(int id)
		{
			RemoveTransportReservationRequest request = new RemoveTransportReservationRequest
			{
				Id = id
			};

				_repository.
			ExecuteProcedureWithParameters<RemoveTransportReservationRequest, RemoveTransportReservationResponse>(request);
		}

		/// <summary>
		/// Updates the row in the table with the given model
		/// </summary>
		/// <param name="model">Model with parameters to be updated in database</param>
		public void UpdateTransportReservationService(CreateTransportModel model)
		{
			UpdateTransportReservationRequest request = new UpdateTransportReservationRequest
			{
				Id = model.Id,
				Date = model.Date,
				ShipmentAmount = model.ShipmentAmount,
				TypeOfTransport = model.SelectedTransportType,
				TypeOfVehicle = model.VehicleType
			};

				_repository.
			ExecuteProcedureWithParameters<UpdateTransportReservationRequest, UpdateTransportReservationResponse>(request);
		}

		/// <summary>
		/// Converts the CreateTransportModel from the view into a request model to be inserted into database
		/// </summary>
		/// <param name="model"></param>
        public void ReservateTransportService(CreateTransportJsonModel model)
		{
			CreateResevationRequestModel transport = new CreateResevationRequestModel
			{
				Date = model.Date,
				ShipmentAmount = model.ShipmentAmount,
				TypeOfTransport = model.SelectedTransportType,
				TypeOfVehicle = model.VehicleType
			};

				_repository.
			ExecuteProcedureWithParameters<CreateResevationRequestModel, CreateReservationResponseModel>(transport);
		}

		public List<VehicleTypeModel> GetVehiclesService(int id)
		{
			GetTypesOfVehiclesRequest request = new GetTypesOfVehiclesRequest
			{
				TransportTypeId = id
			};

			List<GetTypesOfVehiclesResponse> response = _repository.
				GetListStoredProcedureWithParameters<GetTypesOfVehiclesResponse, GetTypesOfVehiclesRequest>(request);

			return response?.Select(vehicle => new VehicleTypeModel(vehicle)).ToList()
				?? Enumerable.Empty<VehicleTypeModel>().ToList();
		}

		/// <summary>
		/// Gets a list of all transports from the database
		/// </summary>
		/// <returns>All reservedTransports converted into TransportModel</returns>
		public List<TransportModel> ListTransportsService()
		{
			RequestAllTransports request = new RequestAllTransports();

			List<ResponseAllTransports> responseModels = _repository.GetListStoredProcedure<ResponseAllTransports, RequestAllTransports>(request);

			return responseModels?.Select(m => new TransportModel(m)).ToList()
				?? Enumerable.Empty<TransportModel>().ToList();
		}
	}
}