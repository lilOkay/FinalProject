using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {   //bütün ürünleri listeler
        IDataResult<List<Product>> GetAll();   //IDaatRsult kullanmamızın sebebi hem succes hem error hem message içermesi
        IDataResult<List<Product>> GetAllByCategory(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();

        //Add de data olmadığı için onu IDataResuolt yapmadık
        IResult Add(Product product);//bundan sonra void olan yerde IResult diyecem  IRsult void yerine kullandık
        IResult Update(Product product);
        IDataResult<Product> GetById(int productId);
    }
}
