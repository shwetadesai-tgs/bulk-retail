using Microsoft.EntityFrameworkCore;
using Product.Core.Domain;
using Product.Core.IRepositories;
using Product.Core.IServices;

namespace Product.Infrastructure.Repositories
{
    public class ProductServices : IProductServices
    {
        #region Fields

        private readonly IProductRepository _productRepository;
        private DbSet<ProductDto> entities;

        #endregion

        #region Ctor

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        public async Task DeleteProductAsync(ProductDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _productRepository.DeleteProductAsync(product.Id);
        }

        public async Task DeleteProductsAsync(IList<ProductDto> products)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));

            foreach (var product in products)
            {
                entities.Remove(product);
                //await _productRepository.DeleteProduct();
            }
        }

        public async Task<IList<ProductDto>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        public async Task<IList<ProductDto>> GetProductsByIdsAsync(int[] productIds)
        {
            return await _productRepository.GetProductsByIdsAsync(productIds);
        }

        public async Task InsertProductAsync(ProductDto product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            await _productRepository.InsertProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            await _productRepository.UpdateProductAsync(product);
        }

        #endregion
    }
}
