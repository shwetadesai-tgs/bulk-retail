using AutoMapper;
using Product.Core.Domain;

namespace BulkRetail.ProductService.Helpers
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Models.ProductModel, ProductDto>();
        }
    }
}
