using Product.Core.Domain;

namespace Product.Core.IRepositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<List<ProductDto>> GetProductsByIdsAsync(int[] productIds);
        Task<List<ProductDto>> GetProductByNameAsync(string name);
        Task InsertProductAsync(ProductDto product);
        Task<bool> UpdateProductAsync(ProductDto product);
        Task<bool> DeleteProductAsync(int id);
    }
}
