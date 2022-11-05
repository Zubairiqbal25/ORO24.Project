using Inlogic.DAL.Context;
using Inlogic.Pos.Entities;

namespace Inlogic.DAL.Repositories
{
    public class ProductData : IProductData
    {
        private readonly ApplicationDbContext _datacontext;
        public ProductData(ApplicationDbContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<List<Product>> getProduct()
        {
            return _datacontext.Products.ToList();
        }
        public async Task<Product> getProduct(Guid id)
        {
            return _datacontext.Products.FirstOrDefault(x => x.Id == id.ToString());
        }
        public async Task<Product> AddProduct(Product data)
        {
            await _datacontext.Products.AddAsync(data);
            await _datacontext.SaveChangesAsync();
            return data;
        }
        public async Task<Product> EditProduct(Guid id, Product data)
        {
            var product = _datacontext.Products.FirstOrDefault(x => x.Id == id.ToString());
            if (product != null)
            {
                if(data.Name != null) { 
                    product.Name = data.Name;
                }
                if(data.Quantity != null) {
                    product.Quantity = data.Quantity; 
                }
                if (data.Image != null)
                {
                    product.Image = data.Image;
                }
                if(data.Price != null) { 
                    product.Price = data.Price;
                }
                await _datacontext.SaveChangesAsync();

                return product;
            }
            else
            {
                return new Product();
            }
        }
        public async Task<string> DeleteProduct(Guid id)
        {
            var seletedProduct = new Product { Id = id.ToString() };
            _datacontext.Products.Remove(seletedProduct);
            await _datacontext.SaveChangesAsync();
            return "successful";
        }
    }
}
