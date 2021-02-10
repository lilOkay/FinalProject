using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>      //aşağıya 4 tane kullanım versiyonunuda yazdık
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //default dataya karşılık gelir
        public ErrorDataResult(string message) : base(default, false, message)//bu ve altındakini çok kullanmayız
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
