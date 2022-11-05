using Inlogic.DAL.Context;
using Inlogic.Pos.Entities;

namespace Inlogic.DAL.Repositories.PlaceOrder
{
    public class OrdersData : IOrdersData
    {
        private readonly ApplicationDbContext _datacontext;
        public OrdersData(ApplicationDbContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<List<Order>> getOrders()
        {
            return _datacontext.Orders.ToList();
        }
        public async Task<Order> getOrderById(Guid id)
        {
            return _datacontext.Orders.FirstOrDefault(x=>x.Id == id.ToString());
            
        }

        public async Task<Order> placeOrder(Order data)
        {
            if (data.Id == null) { 
                data.Id = Guid.NewGuid().ToString();
            }
            data.Created = DateTime.Now;
            await _datacontext.Orders.AddAsync(data);
            await _datacontext.SaveChangesAsync();
            return data;
        }

    }
}
