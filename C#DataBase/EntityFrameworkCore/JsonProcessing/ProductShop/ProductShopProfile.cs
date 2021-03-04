using AutoMapper;
using ProductShop.DTO;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ProductsInRangeDTO>()
                .ForMember(x => x.SellerFullName, y => y
                .MapFrom(x => x.Seller.FirstName + ' ' + x.Seller.LastName));

            this.CreateMap<Product, SoldProductsDTO>()
               .ForMember(x => x.BuyerFirstName, y => y
               .MapFrom(x => x.Buyer.FirstName))
               .ForMember(x => x.BuyerLastName, y => y
               .MapFrom(x => x.Buyer.LastName));

            this.CreateMap<User, UsersWithSoldProductsDTO>()
                .ForMember(x => x.SoldProducts, y => y
                .MapFrom(x => x.ProductsSold.Where(p => p.Buyer != null)));

            this.CreateMap<Category, CategoriesByProductsCountDTO>()
                .ForMember(x => x.AveragePrice, y => y
                .MapFrom(x => x.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2")))
                .ForMember(x => x.TotalRevenue, y => y
                .MapFrom(x => x.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")))
                .ForMember(x => x.ProductsCount, y => y
                .MapFrom(x => x.CategoryProducts.Count));
        }
    }
}
