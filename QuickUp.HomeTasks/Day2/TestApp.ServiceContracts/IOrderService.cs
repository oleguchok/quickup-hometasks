using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestApp.DAL.Model;

namespace TestApp.ServiceContracts
{
    public interface IOrderService
    {
        Order GetOrderById(int id);
        IEnumerable<Order> GetAll(Expression<Func<Order, bool>> where = null);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void RemoveOrder(Order order);
        void SaveOrder();
    }
}
