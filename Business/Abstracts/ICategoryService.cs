﻿using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        IDataResult<Category> GetCategory(int id);
        IDataResult<List<Category>> GetAllCategory();
       
    }
}
