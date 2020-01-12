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
            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderDto, Order>();
            Mapper.CreateMap<Meal, MealDto>();
            Mapper.CreateMap<MealDto, Meal>();
        }
    }
}