using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);

        void SetCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int id);

        IEnumerable<Category> GetAllCategory();
    }
}
