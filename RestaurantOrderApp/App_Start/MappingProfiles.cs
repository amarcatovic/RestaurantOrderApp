using AutoMapper;
using RestaurantOrderApp.Dtos;
using RestaurantOrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantOrderApp.App_Start
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            Mapper.CreateMap<Drink, DrinkDto>();
            Mapper.CreateMap<DrinkDto, Drink>();
        }
    }
}