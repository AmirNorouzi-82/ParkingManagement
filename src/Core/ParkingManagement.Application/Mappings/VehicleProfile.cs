using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain;

namespace ParkingManagement.Application.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CreateVehicleDTO, Vehicle>()
                .ForMember(dest => dest.RegisteredAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateVehicleDTO, Vehicle>();

            CreateMap<Vehicle, VehicleDTO>();
        }
    }
}