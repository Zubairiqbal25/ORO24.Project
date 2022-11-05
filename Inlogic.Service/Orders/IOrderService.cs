using Inlogic.Pos.Entities;

namespace Inlogic.Services.Orders
{
    public interface IOrderService
    {
        Task<List<Order>> getOrders();
        Task<Order> getOrderById(Guid id);
        Task<Order> PlaceOrder(Order Data);
    }
}