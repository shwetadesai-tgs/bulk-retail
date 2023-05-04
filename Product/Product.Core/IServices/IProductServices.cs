using Product.Core.Domain;

namespace Product.Core.IServices
{
    public interface IProductServices
    {
        Task<ProductDto> GetProductByIdAsync(int productId);

        /// <summary>
        /// Gets products by identifier
        /// </summary>
        /// <param name="productIds">Product identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the products
        /// </returns>
        Task<IList<ProductDto>> GetProductsByIdsAsync(int[] productIds);

        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertProductAsync(ProductDto product);

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateProductAsync(ProductDto product);

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteProductAsync(ProductDto product);

        /// <summary>
        /// Delete products
        /// </summary>
        /// <param name="products">Products</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteProductsAsync(IList<ProductDto> products);

        /// <summary>
        /// Gets all products displayed on the home page
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the products
        /// </returns>
        Task<IList<ProductDto>> GetAllProductsAsync();
    }
}
