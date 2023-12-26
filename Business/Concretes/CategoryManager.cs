using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal) 
        {
            _categoryDal = categoryDal;
        }
        [SecuredOperation("admin")]
        public IResult AddCategory(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult("Yeni Kategori Eklendi");
        }

        [SecuredOperation("admin")]
        public IResult DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult("Kategori Silindi");
        }

        public IDataResult<List<Category>> GetAllCategory()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll().ToList());
        }

        public IDataResult<Category> GetCategory(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryID == id));
        }
        [SecuredOperation("admin")]
        public IResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult("Kategori Güncellendi");
        }
    }
}
