using AutoMapper;
using EvidencijaTransporta.DataAccess.Models.InsertStorageInformation;
using EvidencijaTransporta.Web.Models.WarehouseModels;

namespace EvidencijaTransporta.Web.Mapping
{
	public abstract class WarehouseMapperProfile : Profile
	{
		protected readonly IMapper _mapper;
		public WarehouseMapperProfile()
		{
			var config = new MapperConfiguration(y =>
			{
				y.CreateMap<StorageModel, InsertStorageInformationRequest>()
					.ForMember(x => x.Amount, otp => otp.MapFrom(x => x.Amount))
					.ForMember(x => x.DateStored, otp => otp.MapFrom(x => x.DateStored))
					.ForMember(x => x.DateCleared, otp => otp.MapFrom(x => x.DateCleared))
					.ForMember(x => x.Type, otp => otp.MapFrom(x => x.Type))
					.ForMember(x => x.WarehouseId, otp => otp.MapFrom(x => x.WarehouseId));
			});

			_mapper = config.CreateMapper();
		}
	}
}