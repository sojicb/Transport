using EvidencijaTransporta.DataAccess;
using EvidencijaTransporta.DataAccess.Models.CreateReservation;
using EvidencijaTransporta.DataAccess.Models.GetStorageInformation;
using EvidencijaTransporta.DataAccess.Models.InsertStorageInformation;
using EvidencijaTransporta.DataAccess.Models.ListAllWarehouses;
using EvidencijaTransporta.DataAccess.Models.ListOfAllTransports;
using EvidencijaTransporta.DataAccess.Models.RemoveTransportReservation;
using EvidencijaTransporta.DataAccess.Models.UpdateTransportReservation;
using EvidencijaTransporta.Web.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvidencijaTransporta.IntegrationTests
{
	[TestClass]
	public class WarehousingServiceTests
	{
        protected Repository _repository = new Repository();
        protected TransportService _service;

        [SetUp]
        public void SetUp()
        {
            CreateResevationRequestModel requestReservation = new CreateResevationRequestModel
            {
                ShipmentAmount = "50",
                TypeOfTransport = 1,
                Date = DateTime.Now,
                TypeOfVehicle = "Truck"
            };

            _repository.ExecuteProcedureWithParameters<CreateResevationRequestModel, CreateReservationResponseModel>(requestReservation);
        }

		[TearDown]
		public void TearDown()
		{
            var request = new RequestAllTransports();
            
            var transports = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);
            var requestToDelete = new RemoveTransportReservationRequest()
            {
                Id = transports.Last().Id
            };
            _repository.ExecuteProcedureWithParameters<RemoveTransportReservationRequest, RemoveTransportReservationResponse>(requestToDelete);
        }

		[Test]
        public void Repository_GetAllReservations_GetRightTypeOfTransport()
        {
            //Arrange
            var request = new RequestAllTransports();

            //Act
            var transports = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);
            //Assert
            transports.Last().TypeOfTransport.Should().Be("Road");
        }

        [Test]
        public void Repository_GetAllReservations_GetRightShipmentAmount()
        {
            //Arrange
            var request = new RequestAllTransports();

            //Act
            var transports = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);
            //Assert
            transports.Last().ShipmentAmount.Should().Be("50");
        }

        [Test]
        public void Repository_GetAllReservations_GetRightVehicle()
        {
            //Arrange
            var request = new RequestAllTransports();

            //Act
            var transports = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);
            //Assert
            transports.Last().TypeOfVehicle.Should().Be("Truck");
        }

        [Test]
        public void Repository_UpdateReservations_GetRightShipmentAmount()
        {
            //Arrange
            var request = new RequestAllTransports();
            var transports = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);
            var updateRequest = new UpdateTransportReservationRequest()
            {
                Id = transports.Last().Id,
                ShipmentAmount = "60",
                TypeOfVehicle = "Boat",
                TypeOfTransport = 4
            };

            //Act
            _repository.ExecuteProcedureWithParameters<UpdateTransportReservationRequest, UpdateTransportReservationResponse>(updateRequest);
            var result = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);

            //Assert
            result.Last().ShipmentAmount.Should().Be("60");
        }

        [Test]
        public void Repository_UpdateReservations_GetRightVehicle()
        {
            //Arrange
            var request = new RequestAllTransports();
            var transports = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);
            var updateRequest = new UpdateTransportReservationRequest()
            {
                Id = transports.Last().Id,
                ShipmentAmount = "60",
                TypeOfVehicle = "Boat",
                TypeOfTransport = 4
            };

            //Act
            _repository.ExecuteProcedureWithParameters<UpdateTransportReservationRequest, UpdateTransportReservationResponse>(updateRequest);
            var result = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);

            //Assert
            result.Last().TypeOfVehicle.Should().Be("Boat");
        }

        [Test]
        public void Repository_UpdateReservations_GetRightTransportType()
        {
            //Arrange
            var request = new RequestAllTransports();
            var transports = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);
            var updateRequest = new UpdateTransportReservationRequest()
            {
                Id = transports.Last().Id,
                ShipmentAmount = "60",
                TypeOfVehicle = "Boat",
                TypeOfTransport = 4
            };

            //Act
            _repository.ExecuteProcedureWithParameters<UpdateTransportReservationRequest, UpdateTransportReservationResponse>(updateRequest);
            var result = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);

            //Assert
            result.Last().TypeOfTransport.Should().Be("Water");
        }

        [Test]
        public void Repository_GetWarehouses_GetListOfWarehouses()
        {
            //Arrange
            var request = new ListAllWarehousesRequest();

            //Act
            var warehouses = _repository.GetListStoredProcedureWithParameters<ListAllWarehousesResponse, ListAllWarehousesRequest>(request);

            //Assert
            warehouses.Should().NotBeNull();
        }

        [Test]
        public void Repository_GetWarehouseStorage_GetStorageInformation()
        {
            //Arrange
            var request = new ListAllWarehousesRequest();

            var warehouses = _repository.GetListStoredProcedureWithParameters<ListAllWarehousesResponse, ListAllWarehousesRequest>(request);

            var id = warehouses.FirstOrDefault().Id;

            var storageRequest = new GetStorageInformationRequest()
            {
                Id = id
            };

            //Act
            var storage = _repository.GetListStoredProcedureWithParameters<GetStorageInformationResponse, GetStorageInformationRequest>(storageRequest);

            //Assert
            storage.Should().BeOfType(typeof(List<GetStorageInformationResponse>));
        }

        [Test]
        public void Repository_GetAllReservations_ShouldBeMoreThan0()
        {
            //Arrange
            var request = new RequestAllTransports();

            //Act
            var transports = _repository.GetListStoredProcedureWithParameters<ResponseAllTransports, RequestAllTransports>(request);
            //Assert
            transports.Should().BeOfType(typeof(List<ResponseAllTransports>));
        }

        [Test]
        public void Repository_InsertStorageInformation_ShouldInsertStorageInWarehouse()
        {
            //Arrange
            var request = new ListAllWarehousesRequest();

            var warehouses = _repository.GetListStoredProcedureWithParameters<ListAllWarehousesResponse, ListAllWarehousesRequest>(request);

            InsertStorageInformationRequest insertRequest = new InsertStorageInformationRequest()
            {
                WarehouseId = warehouses.First().Id,
                Amount = 1,
                DateCleared = DateTime.Now,
                DateStored = DateTime.Now,
                Type = "random"
            };

            //Act
            var storage = _repository.ExecuteProcedureWithParameters<InsertStorageInformationRequest, InsertStorageInformationResponse>(insertRequest);

            //Assert
            storage.Should().BeOfType(typeof(InsertStorageInformationResponse));
        }
    }
}
