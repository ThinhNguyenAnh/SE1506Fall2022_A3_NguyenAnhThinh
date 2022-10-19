using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductById(int id) => ProductDAO.Instance.getProductByID((id));

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();


        public IEnumerable<Category> GetCategories() => ProductDAO.Instance.GetCategories();

        public IEnumerable<Product> GetProductListByName(string keyword) => ProductDAO.Instance.SearchProductByName((keyword));

        public Product InsertProduct(Product product) => ProductDAO.Instance.InsertProduct((product));


        public void UpdateProduct(Product product) => ProductDAO.Instance.Update((product));


        public void DeleteProduct(Product product) => ProductDAO.Instance.Remove(product);

    }
}
