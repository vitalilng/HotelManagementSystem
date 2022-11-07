using AutoMapper;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Shared.Dto;

namespace HotelManagementSystem.Server
{
    /// <summary>
    /// Source and destination objects for mapping
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// we are using the CreateMap method where we specify
        /// the source object and the destination object to map to
        /// </summary>
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDetailsDto>(); //<Tsource, Tdestination>
            CreateMap<UserDataForCreationDto, ApplicationUser>(); //<Tsource, Tdestination>
        }
    }
}
