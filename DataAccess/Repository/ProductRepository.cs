using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DataAcess.DAO;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {

        public bool DeleteProduct(int id)
        {
            return ProductDAO.Instance.Delete(id);
        }

        public bool CreateProduct(Product product)
        {
            return ProductDAO.Instance.Create(product);
        }


        public List<Product> GetAllProduct()
        {
            return ProductDAO.Instance.GetAllProduct();
        }

        public bool UpdateProduct(Product product)
        {
            return ProductDAO.Instance.Update(product);
        }

    }
}
