using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    // Category Servisleri
    public interface ICategoryService
    {
        IResult AddCategory(Category category);
        IResult DeleteCategory(Category category);
        IResult UpdateCategory(Category category);
        IDataResult<Category> GetCategory(int id);
        IDataResult<List<Category>> GetAllCategory();
       
    }
}
