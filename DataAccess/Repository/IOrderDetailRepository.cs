using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;


namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);

    }
}
