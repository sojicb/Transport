using EvidencijaTransporta.DataAccess.Models.InsertStorageInformation;
using EvidencijaTransporta.Web.Mapping;
using EvidencijaTransporta.Web.Models.WarehouseModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EvidencijaTransporta.UnitTests
{
	[TestClass]
	public class MappingTests : WarehouseMapperProfile
	{
		[TestMethod]
		public void MapperShouldMap_CreateWarehouseModel_To_WarehouseDomainModel()
		{
			//Arrange
			var insertStorage = new StorageModel
			{
				Amount = 50,
				DateCleared = new DateTime(2021,2,2),
				DateStored = new DateTime(2021, 1, 2),
				Type = "nesto",
				WarehouseId = 1
			};

			//Act
			var result = _mapper.Map<InsertStorageInformationRequest>(insertStorage);

			//Assert
			result.Amount.Should().Be(insertStorage.Amount);
			result.DateCleared.Should().Be(insertStorage.DateCleared);
			result.DateStored.Should().Be(insertStorage.DateStored);
			result.Type.Should().Be(insertStorage.Type);
			result.WarehouseId.Should().Be(insertStorage.WarehouseId);
		}
	}
}
