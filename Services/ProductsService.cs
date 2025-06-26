using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository iproductRepository;
        public ProductsService()
        {
            iproductRepository = new ProductsRepository();
        }

        public void AddProduct(Products product)
        {
            iproductRepository.AddProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            iproductRepository.DeleteProduct(productId);
        }

        public Products GetProductById(int productId)
        {
            return iproductRepository.GetProductById(productId);
        }

        public List<Products> GetProducts()
        {
            return iproductRepository.GetProducts();
        }

        public List<Products> SearchProducts(string searchTerm)
        {
            return iproductRepository.SearchProducts(searchTerm);
        }

        public void UpdateProduct(Products product)
        {
            iproductRepository.UpdateProduct(product);
        }
    }
}
