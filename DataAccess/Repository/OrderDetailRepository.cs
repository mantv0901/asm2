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
    }
}
