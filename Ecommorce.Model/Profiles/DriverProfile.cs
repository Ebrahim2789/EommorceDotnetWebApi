using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommorce.Model.DTO.Incoming;
using Ecommorce.Model.DTO.Outgoing;
using Ecommorce.Model.Model;

namespace Ecommorce.Model.Profiles
{
    public class DriverProfile : Profile
    {

        public DriverProfile()
        {
            CreateMap<DriverDTO, Driver>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(dst => dst.FirstName,
            opt => opt.MapFrom(src => src.FirstName)
            )
             .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName)
            )
               .ForMember(
                dest => dest.DriverNumber,
                opt => opt.MapFrom(src => src.DriverNumber)
            )
               .ForMember(
                dst => dst.WorldChampionships,
                opt => opt.MapFrom(src => src.WorldChampionships));

            _ = CreateMap<Driver, IDriverDto>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
            )
            .ForMember(
                dest => dest.DriverNumber,
                opt => opt.MapFrom(src => $"{src.DriverNumber}")
            )
            .ForMember(
                dest => dest.WorldChampionships,
                opt => opt.MapFrom(src => src.WorldChampionships)
            );



        }
    }
}
