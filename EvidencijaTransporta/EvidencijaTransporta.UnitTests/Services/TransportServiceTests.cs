using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.CreateReservation;
using EvidencijaTransporta.DataAccess.Models.GetTypesOfVehicles;
using EvidencijaTransporta.DataAccess.Models.ListAllTransportTypes;
using EvidencijaTransporta.DataAccess.Models.RemoveTransportReservation;
using EvidencijaTransporta.DataAccess.Models.UpdateTransportReservation;
using EvidencijaTransporta.Web.Models;
using EvidencijaTransporta.Web.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvidencijaTransporta.UnitTests.Services
{
	[TestClass]
	public class TransportServiceTests
	{
		private Mock<Repository> _repository;
		private List<ListAllTransportTypesResponseModel> _transportResponses;
		private Mock<TransportService> _mockTransportService;

		[TestInitialize]
		public void TestInitialize()
		{
			_repository = new Mock<Repository>();
			_mockTransportService = new Mock<TransportService>();
			_transportResponses = new List<ListAllTransportTypesResponseModel>
			{
				new ListAllTransportTypesResponseModel()
				{
					Id = 3,
					TransportType = "proba"
				}
			};
		}

		[TestMethod]
		public void GetAllTransportTypesService_ShouldReturn_ListOfAllTransports()
		{
			//Arrange
			_repository.Setup(x => x.GetListStoredProcedure<ListAllTransportTypesResponseModel, ListAllTransportTypesRequestModel>(It.
				IsAny<ListAllTransportTypesRequestModel>())).
				Returns(_transportResponses);
			TransportService transportService = new TransportService(_repository.Object);

			//Act
			var result = transportService.GetAllTransportTypesService();

			//Assert
			result.Should().NotBeNull();
			result.Count.Should().Be(1);
		}

		[TestMethod]
		public void GetAllTransportTypesService_ShouldReturn_EmptyList()
		{
			//Arrange
			_repository.Setup(x => x.GetListStoredProcedure<ListAllTransportTypesResponseModel, ListAllTransportTypesRequestModel>(It.IsAny<ListAllTransportTypesRequestModel>())).
				Returns(new List<ListAllTransportTypesResponseModel>());
			TransportService transportService = new TransportService(_repository.Object);

			//Act
			var result = transportService.ListTransportsService();

			//Assert
			result.Should().NotBeNull();
			result.Count.Should().Be(0);
		}

		[TestMethod]
		public void RemoveTransportReservationService_ShouldCall_Repository()
		{
			//Arrange
			RemoveTransportReservationRequest request = new RemoveTransportReservationRequest
			{
				Id = 2
			};
			_repository.Setup(x => x.
			ExecuteProcedureWithParameters<RemoveTransportReservationRequest, RemoveTransportReservationResponse>(It.IsAny<RemoveTransportReservationRequest>())).
			Verifiable();
			TransportService transportService = new TransportService(_repository.Object);

			//Act
			transportService.RemoveTransportReservationService(request.Id);

			//Assert
			_repository.Verify();
		}

		[TestMethod]
		public void UpdateTransportReservationService_ShouldCall_Repository()
		{
			//Arrange
			UpdateTransportReservationRequest request = new UpdateTransportReservationRequest
			{
				Id = 2
			};

			CreateTransportModel model = new CreateTransportModel
			{
				Id = 2 
			};

			_repository.Setup(x => x.
			ExecuteProcedureWithParameters<UpdateTransportReservationRequest, UpdateTransportReservationResponse>(It.IsAny<UpdateTransportReservationRequest>())).
			Verifiable();
			TransportService transportService = new TransportService(_repository.Object);

			//Act
			transportService.UpdateTransportReservationService(model);

			//Assert
			_repository.Verify();
		}

		[TestMethod]
		public void ReservateTransportService_ShouldCall_Repository()
		{
			//Arrange
			CreateResevationRequestModel request = new CreateResevationRequestModel
			{
				ShipmentAmount = "200",
				TypeOfTransport = 3
			};

			CreateTransportJsonModel createTransportJsonModel = new CreateTransportJsonModel
			{
				ShipmentAmount = "200",
				SelectedTransportType = 3,
			};

			_repository.Setup(x => x.
			ExecuteProcedureWithParameters<CreateResevationRequestModel, CreateReservationResponseModel>(It.IsAny<CreateResevationRequestModel>())).
			Verifiable();
			TransportService transportService = new TransportService(_repository.Object);

			//Act
			transportService.ReservateTransportService(createTransportJsonModel);

			//Assert
			_repository.Verify();
		}

		//[TestMethod]
		//public void GetVehiclesService_ShouldReturn_ListOfVehicles()
		//{
		//	//Arrange
		//	GetTypesOfVehiclesRequest request = new GetTypesOfVehiclesRequest
		//	{
		//		TransportTypeId = 1
		//	};
		//	_repository.Setup(x => x.GetListStoredProcedure<GetTypesOfVehiclesRequest, GetTypesOfVehiclesResponse>(It.IsAny<GetTypesOfVehiclesRequest>())).
		//		Returns(_transportResponses);
		//	TransportService transportService = new TransportService(_repository.Object);

		//	//Act
		//	var result = transportService.GetAllTransportTypesService();

		//	//Assert
		//	result.Should().NotBeNull();
		//	result.Count.Should().Be(1);
		//}

	}
}
