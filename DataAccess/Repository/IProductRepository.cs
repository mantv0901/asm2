using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;


namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> expression);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);   
    }
}
