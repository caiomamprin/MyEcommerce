using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly LojaVirtualContext _database;

        public CategoryRepository(LojaVirtualContext database)
        {
            _database = database;
        }

        public void DeleteCategory(int id)
        {
            Category category = GetCategoryById(id);
            _database.Remove(category);
            _database.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _database.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _database.Categories.Find(id);
        }

        public void SetCategory(Category category)
        {
            _database.Add(category);
            _database.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            if(GetCategoryById(category.Id) != null)
            {
                _database.Update(category);
                _database.SaveChanges();
            }
        }
    }
}
