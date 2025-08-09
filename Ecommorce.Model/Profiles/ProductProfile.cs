using AutoMapper;
using Ecommorce.Model.DTO.Incoming;
using Ecommorce.Model.Model;
using Ecommorce.Model.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.Profiles
{
    public class ProductProfile : Profile
    {

        public ProductProfile()
        {

            CreateMap<ProductBrandDTO, ProductBrand>();

            //CreateMap<ProductBrand, ProductBrandDTO>();
            CreateMap<ProductBrandDTO, ProductBrand>().ReverseMap();


            CreateMap<ProductCategoryDTO, Category>();
            CreateMap<Category, ProductCategoryDTO>();

            CreateMap<ProductAttributeDTO, ProductAttribute>();
            CreateMap<ProductAttribute, ProductAttributeDTO>();

            CreateMap<ProductAttributeValuesDTO, ProductAttributeValue>();
            CreateMap<ProductAttributeValue, ProductAttributeValuesDTO>();

            CreateMap<ProductOptionDTO, ProductOption>();

            CreateMap<ProductOption, ProductOptionDTO>();

            CreateMap<ProductOptionValueDTO, ProductOptionValue>();
            CreateMap<ProductOptionValue, ProductOptionValueDTO>();

            CreateMap<ProductDto, Product>().ReverseMap();

            //CreateMap<Product, ProductDTO>().ForMember(dest => dest.p, opt=>opt.MapFrom(src=>src.)



            //CreateMap<ProductPublish, PublishProductDTO>();



        }
    }
}
