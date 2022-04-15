using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Models;

namespace SuperMarketManagement.Repository.SqlRepository
{
    internal class UserRepository : IRepository<User>
    {
        public User Create(User value)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "Insert into Users values('" + value.Username + "','" + value.Password + "','" + value.UserType + "')";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                return value;
            }
        }

        public void Delete(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "Delete Users where Id=@id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                
                cmd.ExecuteNonQuery();

            }
        }

        public List<User> GetAll()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "Select * from  Users ";
            using (var connection = new SqlConnection(connectionString))
            {
                var result = new List<User>();
                connection.Open();

                //vom crea un obiect de tip reader pentru executarea unui select
                using (var reader = new SqlCommand(sql, connection))
                {
                    var queryResult = reader.ExecuteReader();
                    while (queryResult.Read())
                    {
                        var user = GetUserFrom(queryResult);
                        result.Add(user);
                    }
                    return result;
                }
            }
        }
        private User GetUserFrom(SqlDataReader row)
        {
            return new User()
            {
                Id = (int)row["Id"],
                Username = (string)row["username"],
                Password= (string)row["password"],
                UserType = (string)row["UserType"]
            };
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User value)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "update Users set username=@name, password=@password,UserType=@usertype where ID=@id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = value.Username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = value.Password;
                cmd.Parameters.Add("@usertype", SqlDbType.NVarChar).Value = value.UserType;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = value.Id;
                cmd.ExecuteNonQuery();
                return value;
            }
        }

        public List<User> GettFromMultiple()
        {
            throw new NotImplementedException();
        }

        public List<User> GetActiveProduct()
        {
            throw new NotImplementedException();
        }
    }
}
