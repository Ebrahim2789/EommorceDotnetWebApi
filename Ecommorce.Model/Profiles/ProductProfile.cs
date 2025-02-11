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

        public ProductProfile() {

            CreateMap<ProductBrandDTO, ProductBrand>();

            CreateMap<ProductBrand, ProductBrandDTO>();

            CreateMap<ProductCategoryDTO, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryDTO>();

            CreateMap<ProductAttributeDTO, ProductAttribute>();
            CreateMap<ProductAttribute, ProductAttributeDTO>();

            CreateMap<ProductAttributeValuesDTO, ProductAttributeValue>();
            CreateMap<ProductAttributeValue, ProductAttributeValuesDTO>();

            CreateMap<ProductOptionDTO, ProductOption>();

            CreateMap<ProductOption, ProductOptionDTO>();

            CreateMap<ProductOptionValueDTO, ProductOptionValue>();
            CreateMap<ProductOptionValue, ProductOptionValueDTO>();

            CreateMap<PublishProductDTO, ProductPublish>();
            CreateMap<ProductPublish, PublishProductDTO>();












        }
    }
}
