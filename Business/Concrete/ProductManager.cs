using Business.Abstract;
using Business.BusinesAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete              //core katmanı tüm projeşlerde kullanabileceğin katmandır
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        //bir entity manager jendisi hariç başka bir dali enjecte edemez
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;

        }

        //claim product.add ya da admin claimine sahip olması gerek 
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {//atrubite sen bi kodu çağıracağın zaman git bi üstüne bak belli kurala uyanları çağır
         //mesela üstte[log] yazarsan ilk olarak logla alakalı olanlar çalışacaktır
         //business codes
         //validation buraya yapılmaz validationruleste yapılır her şeyi buraya yazmaya kalkarsan burası spagetti olur
         //loglama yapılan şeylerin biryerde kaydını tutmak demek



            //bir kategoryde en fazla 10 ürün olabilir
            //aynı isim de ürün eklenemz kuralını yaz
            //eğer mevcut kategory sayısı 15i geçtiyse sisteme yeni ürün eklenemez
            IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
            CheckIfProductCountOfCategoryCorrcet(product.CategoryId),
            CheckIfCategoryLimitExeded());

            if (result!=null)
            {
                return result;
            }
            _productDal.Add(product);

            return new SuccesResult(Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {//bir iş sınıfı başka sınıfları newlemez
            //iş kodları yazılır
            if (DateTime.Now.Hour == 22)//saat 22den 23 e kadar ürünlerin listlenmesini engellemek istiyoruz demek
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccesDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(P => P.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccesDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountErrorOfCategoryError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrcet(int categoryId)
        {
            //select count(*) from products where categoryId=1 demek oluyor aşağıdaki kod
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountErrorOfCategoryError);
            }
            return new SuccesResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p=>p.ProductName==productName).Any();//any bool dur
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccesResult();
        }

        

        private IResult CheckIfCategoryLimitExeded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExeded);
            }
            return new SuccesResult();
        }
    }
}
