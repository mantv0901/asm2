using BusinessLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    public class MemberDAO
    {
        private static MemberDAO instance;
        private readonly static object lockInstance = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (lockInstance)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
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
        public bool Create(Member member)
        {
            String sql = "INSERT INTO Member(Email,Password,CompanyName,City,Country,[Status])" +
                " VALUES(@Email,@Password,@CompanyName,@City,@Country,1)";
            bool check = false;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Password", member.Password);
                command.Parameters.AddWithValue("@CompanyName", member.CompanyName);
                command.Parameters.AddWithValue("@City", member.City);
                command.Parameters.AddWithValue("@Country", member.Country);
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

      
        
       
        public List<Member> GetAllMember()
        {
            List<Member> members = new List<Member>();
            String sql = "select * from Member where [Status]=1";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Member member = new Member()
                        {
                            MemberId = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            Password = reader.GetString(5),
                            CompanyName = reader.GetString(2),
                            City = reader.GetString(3),
                            Country = reader.GetString(4)
                        };
                        members.Add(member);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return members;
        }

       
        
        public bool Update(Member member)
        {
            String sql = "UPDATE Member SET Email=@Email,Password=@Password,CompanyName=@CompanyName,City=@City,Country=@Country" +
                " WHERE MemberID=@ID";
            bool check = false;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@Password", member.Password);
                command.Parameters.AddWithValue("@CompanyName", member.CompanyName);
                command.Parameters.AddWithValue("@City", member.City);
                command.Parameters.AddWithValue("@Country", member.Country);
                command.Parameters.AddWithValue("@ID", member.MemberId);
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
            String sql = "UPDATE Member SET [Status] =0" +
                " WHERE MemberID=@ID";
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
