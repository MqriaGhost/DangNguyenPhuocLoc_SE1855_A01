using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductsDAO
    {
        private static List<Products> products = new List<Products>
        {
            new Products
            {
                ProductId = 1,
                ProductName = "Pepsi",               
                CategoryId = 1,               
                UnitPrice = 18.00,
                UnitsInStock = 39,                             
            },
            new Products
            {
                ProductId = 2,
                ProductName = "196",
                CategoryId = 2,
                UnitPrice = 19.00,
                UnitsInStock = 50,
            },
            new Products
            {
                ProductId = 3,
                ProductName = "PS Vitamin",
                CategoryId = 3,
                UnitPrice = 20.00,
                UnitsInStock = 20,
            },
            new Products
            {
                ProductId = 4,
                ProductName = "XBox",
                CategoryId = 4,
                UnitPrice = 20.00,
                UnitsInStock = 20,
            },
            new Products
            {
                ProductId = 5,
                ProductName = "Switch",
                CategoryId = 5,
                UnitPrice = 20.00,
                UnitsInStock = 30,
            }
        };
        public static List<Products> GetAllProducts()
        {
            return products;
        }
        public static Products GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.ProductId == productId);
        }
        public static void AddProduct(Products product)
        {            
            int maxId = products.Any() ? products.Max(p => p.ProductId) : 0;
            // Tạo ID mới
            product.ProductId = maxId + 1;
            products.Add(product);
        }
        public static void UpdateProduct(Products product)
        {
            var existing = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.CategoryId = product.CategoryId;
                existing.UnitPrice = product.UnitPrice;
                existing.UnitsInStock = product.UnitsInStock;
            }
        }
        public static void DeleteProduct(int id)
        {
            var toRemove = products.FirstOrDefault(p => p.ProductId == id);
            if (toRemove != null)
            {
                products.Remove(toRemove);
            }
        }
        public static List<Products> SearchProducts(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Products>(products);
            return products
                .Where(p => p.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
