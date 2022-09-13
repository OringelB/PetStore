using PetStore.Models;
using PetStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Tests.FakeRepositories
{
    internal class FakeCategoryRepository : ICategoryRepository
    {
        private IEnumerable<Category> _category;
        public FakeCategoryRepository()
        {
            _category = new List<Category>() { new Category(), new Category(), new Category(), new Category() };

        }

        public void CreateCategory(Category category)
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            return _category;
        }

        public IEnumerable<Category> GetCategoriesById(int id)
        {
            return _category;
        }
    }
}
