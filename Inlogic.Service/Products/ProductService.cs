using Inlogic.DAL.Repositories;
using Inlogic.Pos.Entities;


namespace Inlogic.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductData _productData;
        public ProductService(IProductData productData)
        {
            _productData = productData;
        }
        public async Task<List<Product>> getProduct()
        {
            return await _productData.getProduct();
        }
        public async Task<Product> getProduct(Guid id)
        {
            return await _productData.getProduct(id);
        }
        public async Task<Product> addProduct(Product data)
        {
            data.Id = Guid.NewGuid().ToString();
            return await _productData.AddProduct(data);
        }

        public async Task<Product> updateProduct(Guid id, Product data)
        {
            return await _productData.EditProduct(id, data);
        }
        public async Task<string> deleteProduct(Guid id)
        {
            return await _productData.DeleteProduct(id);
        }



    }
}
