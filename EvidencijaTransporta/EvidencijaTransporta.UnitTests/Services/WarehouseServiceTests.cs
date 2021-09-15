using AutoMapper;
using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.GetStorageInformation;
using EvidencijaTransporta.DataAccess.Models.InsertStorageInformation;
using EvidencijaTransporta.DataAccess.Models.ListAllWarehouses;
using EvidencijaTransporta.Web.Models.WarehouseModels;
using EvidencijaTransporta.Web.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace EvidencijaTransporta.UnitTests.Services
{
	[TestClass]
	public class WarehouseServiceTests
	{
		private Mock<Repository> _repository;
		private Mock<IMapper> _mapper = new Mock<IMapper>();
		private List<ListAllWarehousesResponse> _responses;
		private ListAllWarehousesRequest _request;
		private ListAllWarehousesResponse _response;
		private StorageModel _storage;
		private GetStorageInformationRequest _storageRequest;

		[TestInitialize]
		public void TestInitialize()
		{
			_request = new ListAllWarehousesRequest();
			_response = new ListAllWarehousesResponse
			{
				Id = 1,
				StreetAndNumber = "BB",
				City = "Belgrade",
				Country = "Serbia",
				CurrentCapacity = 1200,
				MaximumCapacity = 1500,
				Name = "Logistcs"
			};
			_storage = new StorageModel
			{
				Amount = 555,
				Id = 3,
				Type = "Proba",
				WarehouseId = 3
			};

			_storageRequest = new GetStorageInformationRequest
			{
				Id = 2
			};

			_responses = new List<ListAllWarehousesResponse>();
			_repository = new Mock<Repository>();
		}

		[TestMethod]
        public void WarehouseService_ListWarehousesService_ReturnListOfWarehouses()
        {
			//Arrange
			_responses.Add(_response);
			_repository.Setup(x => x.
			GetListStoredProcedure<ListAllWarehousesResponse, ListAllWarehousesRequest>(It.IsAny<ListAllWarehousesRequest>())).
			Returns(_responses);
			WarehouseService warehouseService = new WarehouseService(_repository.Object);

			//Act
			var result = warehouseService.ListWarehousesService();

			//Assert
			result.Should().NotBeNull();
			result.Count.Should().Be(1);
		}

		[TestMethod]
		public void WarehouseService_ListWarehousesService_ReturnEmptyList()
		{
			//Arrange
			_repository.Setup(x => x.
			GetListStoredProcedure<ListAllWarehousesResponse, ListAllWarehousesRequest>(It.IsAny<ListAllWarehousesRequest>())).
			Returns(_responses);
			WarehouseService warehouseService = new WarehouseService(_repository.Object);

			//Act
			var result = warehouseService.ListWarehousesService();

			//Assert
			result.Should().NotBeNull();
			result.Count.Should().Be(0);
		}


		[TestMethod]
		public void InsertStorageInformationService_ShouldCall_Repository()
		{
			//Arrange
			_repository.Setup(x => x.
			ExecuteProcedureWithParameters<InsertStorageInformationRequest, InsertStorageInformationResponse>(It.IsAny<InsertStorageInformationRequest>())).
			Verifiable();
			WarehouseService warehouseService = new WarehouseService(_repository.Object);

			//Act
			warehouseService.InsertStorageInformationService(_storage);

			//Assert
			_repository.Verify();
		}


		[TestMethod]
		public void GetStorageInformationForWarehouseService_ShouldReturn_ListOfStorageInformation()
		{
			//Arrange
			List<GetStorageInformationResponse> responses = new List<GetStorageInformationResponse>();
			responses.Add(new GetStorageInformationResponse
			{ 
				Id = 2
			});
			_repository.Setup(x => x.
			GetListStoredProcedureWithParameters<GetStorageInformationResponse, GetStorageInformationRequest>(It.IsAny<GetStorageInformationRequest>())).
			Returns(responses);
			WarehouseService warehouseService = new WarehouseService(_repository.Object);

			//Act
			var result = warehouseService.GetStorageInformationForWarehouseService(_storageRequest.Id);

			//Assert
			result.Should().NotBeNull();
			result.Count.Should().Be(1);
			result.First().Id.Should().Be(_storageRequest.Id);
		}

		[TestMethod]
		public void GetStorageInformationForWarehouseService_ShouldReturn_EmptyList()
		{
			//Arrange
			_repository.Setup(x => x.
			GetListStoredProcedureWithParameters<GetStorageInformationResponse, GetStorageInformationRequest>(It.IsAny<GetStorageInformationRequest>())).
			Returns(new List<GetStorageInformationResponse>());
			WarehouseService warehouseService = new WarehouseService(_repository.Object);

			//Act
			var result = warehouseService.GetStorageInformationForWarehouseService(_storageRequest.Id);

			//Assert
			result.Should().NotBeNull();
			result.Count.Should().Be(0);
		}
	}
}

