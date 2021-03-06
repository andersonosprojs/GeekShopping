using AutoMapper;
using GeekShopping.Product.API.Data.ValueObjects;

namespace GeekShopping.Product.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Model.Product>();
                config.CreateMap<Model.Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
