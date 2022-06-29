using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;
namespace DataAccess.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private PRN211_DB_ASMContext context;
        public OrderRepository()
        {
            context = new PRN211_DB_ASMContext();
        }

        public void Create(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = GetOrder(id);
            order.Status = false;
            Update(order);
        }

        public Order GetOrder(int id)
        {
            return context.Orders.FirstOrDefault(x => x.OrderId == id);
        }

        public IEnumerable<Order> GetOrders(Expression<Func<Order, bool>> ex)
        {
            return context.Orders.Where(ex);
        }

        public void Update(Order order)
        {
            context.Update(order);
            context.SaveChanges(true);
        }
    }
}
