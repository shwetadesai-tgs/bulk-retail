using AutoMapper;
using BulkRetail.ProductService.Models;
using Microsoft.AspNetCore.Mvc;
using Product.Core.Domain;
using Product.Core.IServices;

namespace BulkRetail.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductController(IProductServices productServices,
            IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productServices.GetAllProductsAsync();
            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet,Route("GetProductById")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productServices.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Route("AddNewProduct")]
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var product = _mapper.Map<ProductDto>(productModel);
                await _productServices.InsertProductAsync(product);
                return Ok("Record saved successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Update(ProductModel productModel)
        {
            try
            {
                if (productModel == null || productModel.Id == 0)
                    return BadRequest();

                var product = await _productServices.GetProductByIdAsync(productModel.Id);

                if (product == null)
                    return NotFound();

                product.Name = productModel.Name;
                product.IsActive = productModel.IsActive;
                product.MOQ = productModel.MOQ;
                product.DiscountValue = productModel.DiscountValue;
                product.DiscountType = productModel.DiscountType;
                product.Brand = productModel.Brand;
                product.LastPrice = productModel.LastPrice;
                product.CostPrice = productModel.CostPrice;
                product.MinSalePrice = productModel.MinSalePrice;

                await _productServices.UpdateProductAsync(product);
                return Ok("Record updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productServices.GetProductByIdAsync(id);

            if (product == null)
                return NotFound($"Product Not Found with Id: {id}");

            await _productServices.DeleteProductAsync(product);
            return Ok($"Product Deleted with Id : {id}");
        }
    }
}