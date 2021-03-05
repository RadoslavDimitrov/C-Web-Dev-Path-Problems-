using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Customer, CustomerTotalSalesDto>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.CarsBought, y => y.MapFrom(x => x.Sales.Count))
                .ForMember(x => x.SpentMoney, y => y
                .MapFrom(x => x.Sales
                              .Select(s => s.Car.PartCars
                                                    .Select(pc => pc.Part)
                                                    .Sum(pc => pc.Price)).Sum()));
        }
    }
}
