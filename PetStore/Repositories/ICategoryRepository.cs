using PetStore.Models;

namespace PetStore.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> GetCategoriesById(int id);
        public void CreateCategory(Category category);

    }
}
