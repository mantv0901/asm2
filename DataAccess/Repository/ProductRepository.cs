using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;


namespace DataAccess.Repository
{
    public class ProductRepository:IProductRepository
    {
        private PRN211_DB_ASMContext context;
        public ProductRepository()
        {
            context = new PRN211_DB_ASMContext();
        }
        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(x=> x.ProductId == id);  
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> expression)
        {
            return context.Products.Where(expression);
        }

        public void Create(Product product)
        {
            context.Products.Add(product);
        }

        public void Update(Product product)
        {
            context.Update(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = GetProduct(id);
            product.Status = false;
            Update(product);    
        }

       
    }
}
