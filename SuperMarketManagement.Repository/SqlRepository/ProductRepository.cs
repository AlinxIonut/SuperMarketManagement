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
    public class ProductRepository : IRepository<Product>
    {
        public Product Create(Product value)
        {
            value.ProductStatus = "default";
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "Insert into Product values('" + value.Name + "','" + value.Description + "','" + value.Price + "','" + value.FabricationDate + "','" + value.Brand + "'," + value.ProductStatus + ")";
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
            var sql = "Delete Product where Id=@id";
            var sql2 = "Delete ProductEvaluation where ProductId=@id";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlCommand cmd2 = new SqlCommand(sql2, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd2.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                

            }
        }

        public List<Product> GetAll()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            var sql = "Select * from  Product ";
            using (var connection = new SqlConnection(connectionString))
            {
                var result = new List<Product>();
                connection.Open();

                //vom crea un obiect de tip reader pentru executarea unui select
                using (var reader = new SqlCommand(sql, connection))
                {
                    var queryResult = reader.ExecuteReader();
                    while (queryResult.Read())
                    {
                        var user = GetProductFrom(queryResult);
                        result.Add(user);
                    }
                    return result;
                }
            }
        }
        private Product GetProductFrom(SqlDataReader row)
        {
            return new Product()
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                Description = (string)row["Description"],
                Price = (int)row["Price"],
                FabricationDate = (DateTime)row["FabricationDate"],
                Brand = (string)row["Brand"],
                ProductStatus = (string)row["ProductStatus"]
            };
        }

        private Product GetProductFromMultiple(SqlDataReader row)
        {
            return new Product()
            {
                //Id = (int)row["Id"],
                Name = (string)row["Name"],
                Description = (string)row["Description"],
                Price = (int)row["Price"],
                FabricationDate = (DateTime)row["FabricationDate"],
                Brand = (string)row["Brand"],
                ProductStatus = (string)row["ProductStatus"],
                Category = (string)row["Categorie"]
            };
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product value)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            var sql = "update Product set Name=@name, Description=@description,Price=@price,FabricationDate=@fabricationDate,Brand=@brand,ProductStatus=@productStatus where ID=@id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = value.Name;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = value.Description;
                cmd.Parameters.Add("@price", SqlDbType.BigInt).Value = value.Price;
                cmd.Parameters.Add("@fabricationDate", SqlDbType.DateTime).Value = value.FabricationDate;
                cmd.Parameters.Add("@brand", SqlDbType.NVarChar).Value = value.Brand;
                cmd.Parameters.Add("@productStatus", SqlDbType.NVarChar).Value = value.ProductStatus;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = value.Id;
                cmd.ExecuteNonQuery();
                return value;
            }
        }

        public List<Product> GettFromMultiple()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            var sql = " Select Brand,Product.Name,Description,Price,FabricationDate,ProductStatus,Category.Name as Categorie from Product inner join CategoryType on Product.Id=CategoryType.ProductId inner join Category on Category.Id=CategoryType.CategoryId  where ProductStatus='active' ";
            using (var connection = new SqlConnection(connectionString))
            {
                var result = new List<Product>();
                connection.Open();

                //vom crea un obiect de tip reader pentru executarea unui select
                using (var reader = new SqlCommand(sql, connection))
                {
                    var queryResult = reader.ExecuteReader();
                    while (queryResult.Read())
                    {
                        var user = GetProductFromMultiple(queryResult);
                        result.Add(user);
                    }
                    return result;
                }
            }
        }
       

        public List<Product> GetActiveProduct()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            var selectProduct = "Select * from  Product where ProductStatus='active'";
            using (var connection = new SqlConnection(connectionString))
            {
                var result = new List<Product>();
                connection.Open();

                //vom crea un obiect de tip reader pentru executarea unui select
                using (var reader = new SqlCommand(selectProduct, connection))
                {
                    var queryResult = reader.ExecuteReader();
                    while (queryResult.Read())
                    {
                        var user = GetProductFrom(queryResult);
                        result.Add(user);
                    }
                    return result;
                }
            }
          
        }
    }
}
