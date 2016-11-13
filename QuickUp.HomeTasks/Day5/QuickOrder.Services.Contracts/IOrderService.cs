using System.Collections.Generic;
using QuickOrder.Entities;

namespace QuickOrder.Services.Contracts
{
    public interface IOrderService
    {
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        void SaveChanges();
    }
}
