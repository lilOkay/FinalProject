using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {   //bütün ürünleri listeler
        List<Product> GetAll();
    }
}
