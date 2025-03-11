using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Api_testing.Models;

namespace Api_testing.DAL
{
    public class EmployeeInfo
    {
        private readonly string connector = ConfigurationManager.ConnectionStrings["Api_connector"].ConnectionString;


        public bool Add_Emp(Emp_data employee)
        {

            using (SqlConnection con = new SqlConnection(connector))
            {
                string query = "INSERT INTO Emp_data (name, email, password, phone, address) VALUES (@name, @email, @password, @phone, @address)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", employee.name);
                    cmd.Parameters.AddWithValue("@email", employee.email);
                    cmd.Parameters.AddWithValue("@password", employee.password);
                    cmd.Parameters.AddWithValue("@phone", employee.phone);
                    cmd.Parameters.AddWithValue("@address", employee.address);
                    con.Open();
                    int roweffector = cmd.ExecuteNonQuery();
                    return roweffector > 0;
                }

            }
        }

        public List<Emp_data> show_Employee()
        {
            List<Emp_data> list = new List<Emp_data>();
            using(SqlConnection con = new SqlConnection(connector))
            {
                string query = "Select *from Emp_data";
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Emp_data()
                            {
                                id=Convert.ToInt32(reader["ID"]),
                                name = reader["name"].ToString(),
                                email = reader["email"].ToString(),
                                password = reader["password"].ToString(),
                                phone = reader["phone"].ToString(),
                                address = reader["address"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool Delete_data(int id)
        {
            using(SqlConnection con = new SqlConnection(connector))
            {
                string query = "delete from Emp_data where id=@id";
                using( SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id",id);
                    con.Open();
                   int Exe= cmd.ExecuteNonQuery();

                    return Exe > 0;
                }
            }
        }

        public bool edit(Emp_data data, int id)
        {
            using( SqlConnection con = new SqlConnection(connector))
            {
                string query = "Update Emp_data set name=@name,email=@email,password=@password,phone=@phone,address=@address where id=@id";
                using(SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@id", data.id);
                    cmd.Parameters.AddWithValue("@name", data.name);
                    cmd.Parameters.AddWithValue("email",data.email);
                    cmd.Parameters.AddWithValue("@password",data.password);
                    cmd.Parameters.AddWithValue("@phone",data.phone);
                    cmd.Parameters.AddWithValue("@address",data.address);
                    con.Open();
                    int up= cmd.ExecuteNonQuery();

                }
            }
            return true;
        }


        public List<Emp_data> getuserbyid(int id)
        {
            List<Emp_data> info = new List<Emp_data>();

            using(SqlConnection con = new SqlConnection(connector))
            {
                string query = "select *from Emp_data where id=@id";
                using( SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id",id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info.Add(new Emp_data()
                            {
                                id=Convert.ToInt32(reader["ID"]),
                                name = reader["name"].ToString(),
                                email = reader["email"].ToString(),
                                password = reader["password"].ToString(),
                                phone = reader["phone"].ToString(),
                                address = reader["address"].ToString()

                            });
                            
                        }

                    }
                    
                }
            }
            return info;
           
        }
       

    }
}