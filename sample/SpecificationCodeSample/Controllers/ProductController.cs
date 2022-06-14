using Microsoft.AspNetCore.Mvc;
using SpecificationCode;
using SpecificationCodeSample.Models;
using SpecificationCodeSample.Services;
using SpecificationCodeSample.Specifications;
using System.Net;

namespace SpecificationCodeSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            return StatusCode((int)HttpStatusCode.OK, products);
        }

        [HttpGet("specification")]
        public async Task<IActionResult> GetProductWithSpec()
        {
            var brandSpec = new ProductBrandSpecification("Nivea");
            var underStockSpec = new UnderCriticalStockSpecification(5);
            var underPriceSpec = new UnderSalePriceSpecification(40);

            var spec = brandSpec.And(underStockSpec).And(underPriceSpec);

            var products = await _productService.GetProducts(spec);

            return StatusCode((int)HttpStatusCode.OK, products);
        }

    }
}