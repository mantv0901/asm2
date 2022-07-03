using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class OrderDetailRepository:IOrderDetailRepository
    {
        private PRN211_DB_ASMContext context;
        public OrderDetailRepository()
        {
            context = new PRN211_DB_ASMContext();
        }

        public void Create(OrderDetail orderDetail)
        {
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
        }

        public OrderDetail GetOrderDetail(int orderId)
        {
            return context.OrderDetails.FirstOrDefault(x => x.OrderId == orderId);
        }

        public void Delete(int orderId)
        {
            OrderDetail orderDetail = GetOrderDetail(orderId);
            orderDetail.Status = false;
            Update(orderDetail);
        }

        public void Update(OrderDetail orderDetail)
        {
            context.Update(orderDetail);
            context.SaveChanges(true);
        }
    }
}
