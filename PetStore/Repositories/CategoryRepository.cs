using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using PetStore.Models;

namespace PetStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        PetContext _context;
        public CategoryRepository(PetContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            var categories = _context.Categories!
                       .Include(category => category.Animals!);
            return categories;
        }

        public void CreateCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetCategoriesById(int id)
        {
            if (id == 0)
            {
                return GetCategories();
            }
            var category = _context.Categories!
                .Where(category => category.CategoryId == id)
                .Include(category => category.Animals!);
            return category;
        }
    }
}
