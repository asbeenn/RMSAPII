using AutoMapper;
using DataLayer.Entities;
using Models.PropertyModel;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PropertyDto, Property>().ReverseMap();
            CreateMap<GetPropertyDto, Property>().ReverseMap();
            CreateMap<UpdatePropertyDto, Property>().ReverseMap();

            CreateMap<UserDto,ApplicationUser>().ReverseMap();
            CreateMap<UserRegisterDto, ApplicationUser>().ReverseMap();

            CreateMap<RoleDto, Roles>().ReverseMap();
            CreateMap<UserRoleDto, UserRoles>().ReverseMap();

            CreateMap<BookingDto, Booking>().ReverseMap(); 
            CreateMap<BookingByUserIdDto, Booking>().ReverseMap();
        }
    }
}
