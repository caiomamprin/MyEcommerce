using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Ecommerce.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);

        void SetCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int id);

        IPagedList<Category> GetAllCategory(int? pageIndex);
        IEnumerable<Category> GetAllCategory();
    }
}
