using Inlogic.DAL.Repositories.PlaceOrder;
using Inlogic.Pos.Entities;

namespace Inlogic.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersData _ordersdata;
        public OrderService(IOrdersData ordersdata)
        {
            _ordersdata = ordersdata;
        }
        public async Task<List<Order>> getOrders()
        {
            return await _ordersdata.getOrders();
        }

        public async Task<Order> getOrderById(Guid id)
        {
            return await _ordersdata.getOrderById(id);
        }

        public async Task<Order> PlaceOrder(Order Data)
        {
            return await _ordersdata.placeOrder(Data);
        }
    }
}
