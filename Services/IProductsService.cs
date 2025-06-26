using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductsService
    {
        List<Products> GetProducts();
        Products GetProductById(int productId);
        void AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(int productId);
        List<Products> SearchProducts(string searchTerm);
    }
}
