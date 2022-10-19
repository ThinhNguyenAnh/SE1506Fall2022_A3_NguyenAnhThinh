using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();

        private ProductDAO()
        {
        }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }

                    return instance;
                }
            }
        }


        public IEnumerable<Product> SearchProductByName(string keyword)
        {
            List<Product> product;
            try
            {
                var FStoreDB = new eStoreDBContext();
                var ling = from a in FStoreDB.Products
                           where a.ProductName.Contains(keyword)
                           select a;
                product = ling.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product;
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories;
            try
            {
                var FStoreDB = new eStoreDBContext();
                categories = FStoreDB.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categories;
        }


        public IEnumerable<Product> GetProductList()
        {
            List<Product> prdocuts;
            try
            {
                var FStoreDB = new eStoreDBContext();
                prdocuts = FStoreDB.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return prdocuts;
        }

        public Product getProductByID(int productID)
        {
            Product product = null;
            try
            {
                var FStoreDB = new eStoreDBContext();
                product = FStoreDB.Products.SingleOrDefault(product => product.ID == productID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product;
        }

        public Category GetCategoryById(int categoryID)
        {
            Category category = null;
            try
            {
                var FStoreDB = new eStoreDBContext();
                category = FStoreDB.Categories.SingleOrDefault(category => category.ID == categoryID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return category;
        }


        public Product InsertProduct(Product product)
        {
            try
            {
                Product _product = getProductByID(product.ID);
                if (_product == null)
                {
                    var FStoreDB = new eStoreDBContext();
                    FStoreDB.Products.Add(product);
                    FStoreDB.SaveChanges();
                    return product;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception("Product is already exist");
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product c = getProductByID(product.ID);
                if (c != null)
                {
                    var FStoreDB = new eStoreDBContext();
                    FStoreDB.Entry(product).State = EntityState.Modified;
                    FStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Product product)
        {
            try
            {
                Product _product = getProductByID(product.ID);
                if (_product != null)
                {
                    var FStoreDB = new eStoreDBContext();
                    FStoreDB.Products.Remove(product);
                    FStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
    }
}
