using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestApp.DAL.Infrastructure;
using TestApp.DAL.Model;
using TestApp.DAL.Repositrories;
using TestApp.ServiceContracts;

namespace TestApp.Service
{
    public class OrderService : IOrderService
    {
        private readonly GenericRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(GenericRepository<Order> orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetAll(Expression<Func<Order, bool>> where = null)
        {
            return where == null
                ? _orderRepository.GetAll()
                : _orderRepository.GetMany(where);
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _orderRepository.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _orderRepository.Update(order);
        }

        public void RemoveOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _orderRepository.Delete(order);
        }

        public void SaveOrder()
        {
            _unitOfWork.Commit();
        }
    }
}
