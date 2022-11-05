using Inlogic.Pos.Entities;

namespace Inlogic.DAL.Repositories.PlaceOrder
{
    public interface IOrdersData
    {
        Task<List<Order>> getOrders();
        Task<Order> getOrderById(Guid id);
        Task<Order> placeOrder(Order data);

    }
}
