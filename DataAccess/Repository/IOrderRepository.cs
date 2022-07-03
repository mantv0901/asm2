using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        Order GetOrder(int id);
        int GetMax();
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrdersBy(Expression<Func<Order, bool>> ex);
        void Create(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
