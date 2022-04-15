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
    internal class CategoryRepository : IRepository<Category>
    {
        public Category Create(Category value)
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "Insert into Category values('" + value.Name + "')";
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
            var sql = "Delete Category where Id=@id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                
            }
        }

        public List<Category> GetAll()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "Select * from  Category ";
            using (var connection = new SqlConnection(connectionString))
            {
                var result = new List<Category>();
                connection.Open();

                //vom crea un obiect de tip reader pentru executarea unui select
                using (var reader = new SqlCommand(sql, connection))
                {
                    var queryResult = reader.ExecuteReader();
                    while (queryResult.Read())
                    {
                        var category = GetCategoryFrom(queryResult);
                        result.Add(category);
                    }
                    return result;
                }
            }
        }
        private Category GetCategoryFrom(SqlDataReader row) 
        {
            return new Category()
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"]
             };
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category value)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "update Category set Name=@name where ID=@id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = value.Name;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = value.Id;
                cmd.ExecuteNonQuery();
                return value;
            }
        }

        public List<Category> GettFromMultiple()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetActiveProduct()
        {
            throw new NotImplementedException();
        }
    }
}
