using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain;
using ParkingManagement.Domain.Enums; // برای PaymentStatus

namespace ParkingManagement.Application.Mappings
{
    public class ParkingLogProfile : Profile
    {
        public ParkingLogProfile()
        {
            CreateMap<CreateParkingLogDTO, ParkingLog>()
                .ForMember(dest => dest.EntryTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => PaymentStatus.Pending)) // ← اصلاح شد
                .ForMember(dest => dest.ExitTime, opt => opt.Ignore())
                .ForMember(dest => dest.Cost, opt => opt.Ignore());

            CreateMap<UpdateParkingLogDTO, ParkingLog>();

            CreateMap<ParkingLog, ParkingLogDTO>();
        }
    }
}