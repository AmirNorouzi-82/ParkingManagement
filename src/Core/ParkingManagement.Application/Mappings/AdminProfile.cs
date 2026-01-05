using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain;

namespace ParkingManagement.Application.Mappings
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<CreateAdminDTO, Admin>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateAdminDTO, Admin>();

            CreateMap<Admin, AdminDTO>();
        }
    }
}