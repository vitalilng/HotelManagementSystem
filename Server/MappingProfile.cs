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
            CreateMap<UserDataForUpdateDto, ApplicationUser>().ReverseMap(); //<Tsource, Tdestination> <-> two way mapping            

            CreateMap<Room, RoomDto>();
            CreateMap<RoomDataForCreationDto, Room>();
            CreateMap<RoomDataForUpdateDto, Room>().ReverseMap();

            CreateMap<Transaction, TransactionDto>();
            CreateMap<Transaction, TransactionDataToDisplayDto>()
                .ForMember(dto => dto.UserName, conf => conf.MapFrom(ol => ol.ApplicationUser.UserName))
                .ForMember(dto => dto.RoomType, conf => conf.MapFrom(ol => ol.Room.RoomType)); 
            CreateMap<TransactionDataForCreationDto, Transaction>();
            CreateMap<TransactionDataForUpdateDto, Transaction>().ReverseMap();
        }
    }
}
