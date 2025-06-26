using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public void AddCategory(Categories category)
        {
            CategoriesDAO.AddCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            CategoriesDAO.DeleteCategory(categoryId);
        }

        public List<Categories> GetCategories()
        {
            return CategoriesDAO.GetAllCategories();
        }

        public Categories GetCategoryById(int categoryId)
        {
            return CategoriesDAO.GetCategoryById(categoryId);
        }

        public List<Categories> SearchCategories(string searchTerm)
        {
            return CategoriesDAO.SearchCategories(searchTerm);
        }

        public void UpdateCategory(Categories category)
        {
            CategoriesDAO.UpdateCategory(category);
        }
    }
}
