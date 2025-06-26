using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductsRepository
    {
        List<Products> GetProducts();
        Products GetProductById(int productId);
        void AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(int productId);
        List<Products> SearchProducts(string searchTerm);
    }
}
