using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Ecommerce.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _config;
        private readonly LojaVirtualContext _database;

        public CategoryRepository(LojaVirtualContext database, IConfiguration config)
        {
            _database = database;
            _config = config;
        }

        public void DeleteCategory(int id)
        {
            Category category = GetCategoryById(id);
            _database.Remove(category);
            _database.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _database.Categories;
        }
        IPagedList<Category> ICategoryRepository.GetAllCategory(int? pageIndex)
        {
            int pageSize = _config.GetValue<int>("PageSize");
            int pageNumber = pageIndex ?? 1;
            return _database.Categories.Include(a=>a.CategoryFather).ToPagedList<Category>(pageNumber, pageSize);
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
                _database.Update(category);
                _database.SaveChanges();
        }

    }
}
