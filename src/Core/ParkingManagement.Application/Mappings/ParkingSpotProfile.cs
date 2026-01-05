using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain;
using ParkingManagement.Domain.Enums;

namespace ParkingManagement.Application.Mappings
{
    public class ParkingSpotProfile : Profile
    {
        public ParkingSpotProfile()
        {
            CreateMap<CreateParkingSpotDTO, ParkingSpot>()
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsReserved, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.LastOccupiedTime, opt => opt.Ignore())
                .ForMember(dest => dest.LastVacatedTime, opt => opt.Ignore());

            CreateMap<UpdateParkingSpotDTO, ParkingSpot>();

            CreateMap<ParkingSpot, ParkingSpotDTO>();
        }
    }
}