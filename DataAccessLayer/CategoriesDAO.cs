using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoriesDAO
    {
        private static List<Categories> categories = new List<Categories>
        {
            new Categories{
                CategoryId = 1,
                CategoryName = "Beverages",
                Description = "Soft drinks, coffees, teas, beers, and ales"
            },
            new Categories{
                CategoryId = 2,
                CategoryName = "Condiments",
                Description = "Sweet and savory sauces, relishes, spreads, and seasonings"
            },
            new Categories{
                CategoryId = 3,
                CategoryName = "Confections",
                Description = "Desserts, candies, and sweet breads"
            },
            new Categories{
                CategoryId = 4,
                CategoryName = "Dairy Products",
                Description = "Cheeses"
            },
            new Categories{
                CategoryId = 5,
                CategoryName = "Grains/Cereals",
                Description = "Breads, crackers, pasta, and cereal"
            }
        };
        public static List<Categories> GetAllCategories()
        {
            return categories;
        }
        public static Categories GetCategoryById(int id)
        {
            return categories.FirstOrDefault(c => c.CategoryId == id);
        }
        public static void AddCategory(Categories category)
        {
            if (category != null && !categories.Any(c => c.CategoryId == category.CategoryId))
            {
                categories.Add(category);
            }
        }
        public static void UpdateCategory(Categories category)
        {
            if (category != null)
            {
                var existingCategory = GetCategoryById(category.CategoryId);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = category.CategoryName;
                    existingCategory.Description = category.Description;
                }
            }
        }
        public static void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                categories.Remove(category);
            }
        }
        public static List<Categories> SearchCategories(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return categories;
            }
            return categories.Where(c => c.CategoryName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                          c.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
