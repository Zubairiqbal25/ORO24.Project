using Inlogic.Pos.Entities;

namespace Inlogic.Services.Products
{
    public interface IProductService
    {
        Task<Product> addProduct(Product data);
        Task<string> deleteProduct(Guid id);
        Task<List<Product>> getProduct();
        Task<Product> getProduct(Guid id);
        Task<Product> updateProduct(Guid id, Product data);
    }
}