using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Supplier, ExportLocalSuppliersDto>();

            this.CreateMap<Car, ExportCarsWithDistanceDto>();

            this.CreateMap<Car, ExportCarsBmwDto>();

            this.CreateMap<PartCar, ExportPartsDto>()
               .ForMember(pc => pc.Name, p => p.MapFrom(pc => pc.Part.Name))
               .ForMember(pc => pc.Price, c => c.MapFrom(pc => pc.Part.Price));

            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(x => x.Parts, y => y.MapFrom(s => s.PartCars.OrderByDescending(pc => pc.Part.Price)));
        }
    }
}
