using BusinessLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        private readonly static object lockInstance = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (lockInstance)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public String GetConnectionString()
        {
            var config = new ConfigurationBuilder().AddJsonFile("jsconfig.json").Build();
            string ConnectionStr = config.GetConnectionString("Test");
            return ConnectionStr;

        }
        public bool Create(Product product)
        {
            String sql = "INSERT INTO Product(CategoryId,ProductName,UnitPrice,UnitsInStock,[Status],weight)" +
                " VALUES(@CategoryId,@ProductName,@UnitPrice,@UnitsInStock,1,@weight)";
            bool check = false;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
                command.Parameters.AddWithValue("@weight", product.Weight);
                try
                {
                    connection.Open();
                    int a = command.ExecuteNonQuery();
                    if (a > 0) check = true;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return check;
        }




        public List<Product> GetAllProduct()
        {
            List<Product> product = new List<Product>();
            String sql = "select * from Product where [Status]=1";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product1 = new Product()
                        {
                            ProductId = reader.GetInt32(0),
                            CategoryId = reader.GetInt32(1),
                            ProductName = reader.GetString(3),
                            UnitPrice = reader.GetInt32(4),
                            UnitsInStock = reader.GetInt32(5),
                            Weight = reader.GetString(6)
                        };
                        product.Add(product1);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return product;
        }



        public bool Update(Product product)
        {
            String sql = "UPDATE Product SET CategoryId=@CategoryId,ProductName=@ProductName,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,weight=@weight" +
                " WHERE ProductId=@ID";
            bool check = false;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
                command.Parameters.AddWithValue("@weight", product.Weight);
                command.Parameters.AddWithValue("@ID", product.ProductId);
                try
                {
                    connection.Open();
                    int a = command.ExecuteNonQuery();
                    if (a > 0) check = true;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return check;
        }
        public bool Delete(int id)
        {
            String sql = "UPDATE Product SET [Status] =0" +
                " WHERE ProductID=@ID";
            bool check = false;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID", id);
                try
                {
                    connection.Open();
                    int a = command.ExecuteNonQuery();
                    if (a > 0) check = true;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return check;
        }
    }
}