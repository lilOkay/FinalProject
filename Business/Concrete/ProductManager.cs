using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete              //core katmanı tüm projeşlerde kullanabileceğin katmandır
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {//atrubite sen bi kodu çağıracağın zaman git bi üstüne bak belli kurala uyanları çağır
            //mesela üstte[log] yazarsan ilk olarak logla alakalı olanlar çalışacaktır
            //business codes
            //validation



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

            return new SuccesDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccesDataResult<List<Product>> (_productDal.GetAll(P => P.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccesDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }
    }
}
