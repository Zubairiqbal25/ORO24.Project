using Inlogic.Pos.Entities;
using Inlogic.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Inlogic.PosSolution.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }
        [HttpGet]
        [Route("getProducts")]
        public async Task<IActionResult> getProducts()
        {
            try {
                var Token = Request.Headers.Authorization;

                var Result = await _productservice.getProduct();
                if(Result.Count == 0)
                {
                    return NotFound("No Item Found");
                }
                else
                { 
                    return Ok(Result);
                }
            }
            catch (Exception) { throw; }
        }
        [HttpPost]
        [Route("getProductsById")]
        public async Task<IActionResult> getProducts(Guid id)
        {
            try { 
                var Result = await _productservice.getProduct(id);
                if (Result == null)
                {
                    return NotFound("No Item Found");
                }
                else { 
                    return Ok(Result);
                }
            }
            catch (Exception) { throw; }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(Product data)
        {
            try { 
                var Result = await _productservice.addProduct(data);
                return Ok(Result);
            }
            catch (Exception) { throw; }
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Guid id,Product data)
        {
            try { 
                var Result = await _productservice.updateProduct(id, data);
                if(Result != null && Result.Name != null) { 
                    return Ok(Result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception) { throw; }
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try { 
                var Result = await _productservice.deleteProduct(id);
                return Ok(Result);
            }
            catch (Exception) { throw; }
        }


    }
}
