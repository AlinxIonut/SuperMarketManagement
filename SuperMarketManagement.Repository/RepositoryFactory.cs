using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketManagement.Models;
using SuperMarketManagement.Repository.SqlRepository;

namespace SuperMarketManagement.Repository
{
    public class RepositoryFactory
    {
        public static IRepository<User> CreateUserRepository()
        {
            return new SuperMarketManagement.Repository.SqlRepository.UserRepository();
        }
        public static IRepository<Product> CreateProductRepository()
        {
            var repType = Convert.ToInt32(ConfigurationManager.AppSettings["repType"]);
            

            switch (repType)
            {
                case (int)RepositoryType.Sql: return new SuperMarketManagement.Repository.SqlRepository.ProductRepository();
                case (int)RepositoryType.Json: return new SuperMarketManagement.Repository.JsonRepository.ProductRepository();
            }

            return new SuperMarketManagement.Repository.SqlRepository.ProductRepository();
        }
        public static IRepository<Category> CreateCategoryRepository()
        {
            return new SuperMarketManagement.Repository.SqlRepository.CategoryRepository();
        }
        public static IRepository<CategoryType> CreateCategoryTypeRepository()
        {
            return new SuperMarketManagement.Repository.SqlRepository.CategoryTypeRepository();
        }
        public static IRepository<ProductEvaluation> CreateProductEvaluationRepository()
        {
            return new SuperMarketManagement.Repository.SqlRepository.ProductEvaluationRepository();
        }
    
    }
}
