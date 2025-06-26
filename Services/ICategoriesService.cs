using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoriesService
    {
        List<Categories> GetCategories();
        Categories GetCategoryById(int categoryId);
        void AddCategory(Categories category);
        void UpdateCategory(Categories category);
        void DeleteCategory(int categoryId);
        List<Categories> SearchCategories(string searchTerm);

    }
}
