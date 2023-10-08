using AutoMapper;
using DataLayer.Entities;
using Models.PropertyModel;
using Models.ViewModel;
using System;
using System.Collections.Generic;
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
            CreateMap<UpdatePropertyDto, Property>().ReverseMap();

            CreateMap<UserDto,ApplicationUser>().ReverseMap();

            CreateMap<BookingDto, Booking>().ReverseMap();
        }
    }
}
