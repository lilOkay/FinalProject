using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{//doğrulama kuralları
    public class ProductValidator:AbstractValidator<Product>
    {//ctor un içine yazılır
        public ProductValidator()
        {//ctrl k+d kodunu düzenler kullanışlı
            RuleFor(p=>p.ProductName).NotEmpty();
            RuleFor(p=>p.ProductName).MinimumLength(2);
            RuleFor(p=>p.UnitPrice).NotEmpty();
            RuleFor(p=>p.UnitPrice).GreaterThan(0);
            RuleFor(P=>P.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId==1);//p nin category idsi 1 olursa enaz 10 olmak zorunda
            RuleFor(p=>p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
            //RuleFor(p=>p.CategoryId).LessThanOrEqualTo(10);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
