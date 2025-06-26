using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public void AddProduct(Products product)
        {
            ProductsDAO.AddProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            ProductsDAO.DeleteProduct(productId);
        }

        public Products GetProductById(int productId)
        {
            return ProductsDAO.GetProductById(productId);
        }

        public List<Products> GetProducts()
        {
            return ProductsDAO.GetAllProducts();
        }

        public List<Products> SearchProducts(string searchTerm)
        {
            return ProductsDAO.SearchProducts(searchTerm);
        }

        public void UpdateProduct(Products product)
        {
            ProductsDAO.UpdateProduct(product);
        }
    }
}
