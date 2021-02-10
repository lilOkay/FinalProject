using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    public interface IResult
    {
        //mesela ekleme işi yapmak istiyon yan başarılı yada değil
        bool Succes { get; }//get demek sadece okunabilir demek get demek return et demek
        string Message { get; }
    }
}
