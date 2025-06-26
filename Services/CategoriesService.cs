using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository icategoryRepository;

        public CategoriesService()
        {
            
            icategoryRepository = new CategoriesRepository(); 
        }
        public void AddCategory(Categories category)
        {
            icategoryRepository.AddCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            icategoryRepository.DeleteCategory(categoryId);
        }

        public List<Categories> GetCategories()
        {
            return icategoryRepository.GetCategories();
        }

        public Categories GetCategoryById(int categoryId)
        {
            return icategoryRepository.GetCategoryById(categoryId);
        }

        public List<Categories> SearchCategories(string searchTerm)
        {
            return icategoryRepository.SearchCategories(searchTerm);
        }

        public void UpdateCategory(Categories category)
        {
            icategoryRepository.UpdateCategory(category);
        }
    }
}
