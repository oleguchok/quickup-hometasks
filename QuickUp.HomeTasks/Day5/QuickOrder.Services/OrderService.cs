using System.Collections.Generic;
using QuickOrder.DAL.Infrastructure;
using QuickOrder.Entities;
using QuickOrder.Services.Contracts;

namespace QuickOrder.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEntityBaseRepository<Order> _ordeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IEntityBaseRepository<Order> ordeRepository, IUnitOfWork unitOfWork)
        {
            _ordeRepository = ordeRepository;
            _unitOfWork = unitOfWork;
        }

        public Order GetOrderById(int id)
        {
            return _ordeRepository.GetById(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ordeRepository.GetAll();
        }

        public void AddOrder(Order order)
        {
            _ordeRepository.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            _ordeRepository.Update(order);
        }

        public void DeleteOrder(Order order)
        {
            _ordeRepository.Delete(order);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
