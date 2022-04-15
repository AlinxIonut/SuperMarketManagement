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
    internal class ProductEvaluationRepository : IRepository<ProductEvaluation>
    {
        public ProductEvaluation Create(ProductEvaluation value)
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "Insert into ProductEvaluation values('" + value.Description + "','" + value.Rating + "','" + value.ProductId + "','" + value.UserId + "')";
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
            var sql = "Delete ProductEvaluation where UserId=@id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();

            }
        }

        public List<ProductEvaluation> GetActiveProduct()
        {
            throw new NotImplementedException();
        }

        public List<ProductEvaluation> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductEvaluation GetById(int id)
        {
            throw new NotImplementedException();
        }

    
     

        public ProductEvaluation Update(ProductEvaluation value)
        {
            throw new NotImplementedException();
        }

        public List<ProductEvaluation> GettFromMultiple()
        {
            throw new NotImplementedException();
        }
    }
}
