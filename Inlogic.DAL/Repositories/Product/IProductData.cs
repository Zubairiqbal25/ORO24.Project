using Inlogic.Pos.Entities;

namespace Inlogic.DAL.Repositories
{
    public interface IProductData
    {
        Task<Product> AddProduct(Product data);
        Task<string> DeleteProduct(Guid id);
        Task<Product> EditProduct(Guid id, Product data);
        Task<List<Product>> getProduct();
        Task<Product> getProduct(Guid id);
    }
}