using AutoMapper;
using GarageManager.Domain.DataModels;
using GarageManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Application.Automapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Vehicle, VehicleModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<VehicleAdmission, VehicleAdmissionModel>().ReverseMap();
        }
    }
}
