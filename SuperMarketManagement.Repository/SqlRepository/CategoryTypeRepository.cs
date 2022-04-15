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
    internal class CategoryTypeRepository : IRepository<CategoryType>
    {
        public CategoryType Create(CategoryType value)
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "Insert into CategoryType(CategoryId,ProductId) values('" + value.CategoryId + "','" + value.ProductId + "')";
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
            var sql = "Delete CategoryType where ProductId=@id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();

            }
        }

        public List<CategoryType> GetActiveProduct()
        {
            throw new NotImplementedException();
        }

        public List<CategoryType> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryType> GettFromMultiple()
        {
            throw new NotImplementedException();
        }

        public CategoryType Update(CategoryType value)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "update CategoryType set ProductId=@pId, CategoryId=@cId where ProductId=@pId";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@pId", SqlDbType.BigInt).Value = value.ProductId;
                cmd.Parameters.Add("@cId", SqlDbType.BigInt).Value = value.CategoryId;
        
                cmd.ExecuteNonQuery();
                return value;
            }
        }
    }
}
