using SuperMarketManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace SuperMarketManagement.Repository.JsonRepository
{

    public class ProductRepository : IRepository<Product>
    {
   
        public List<Product> Products;
        public ProductRepository()
        {
            Products = new List<Product>();
        }
        public Product Create(Product value)
        {
            Products.Add(value);
            return value;
        }

        public void Delete(int id)
        {
         
        }

        public List<Product> GetActiveProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {

            throw new NotImplementedException();

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

        public Product GetById(int id)
        {
            throw new NotImplementedException();
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
        public void ImportJson()
        {
            var filePath = ConfigurationManager.AppSettings["ProductPath"];

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            File.WriteAllText(Path.Combine(filePath, $"Of.json"), JsonConvert.SerializeObject(GettFromMultiple()));

        }

        public Product Update(Product value)
        {
            throw new NotImplementedException();
        }
    }
}
