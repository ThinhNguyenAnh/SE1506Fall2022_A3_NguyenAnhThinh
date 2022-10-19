using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IProductRepository
    {

        public Product GetProductById(int id);

        IEnumerable<Product> GetProducts();

        IEnumerable<Category> GetCategories();

        public IEnumerable<Product> GetProductListByName(string keyword);

        Product InsertProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
    }
}
