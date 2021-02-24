using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{//her entitynin kendi sevisi olacak
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodlarımı yazarım 
            return new SuccesDataResult<List<Category>>(_categoryDal.GetAll());
        }
        //sellect * from Categories where categoryıd 3
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccesDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        IDataResult<List<Category>> ICategoryService.GetById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
