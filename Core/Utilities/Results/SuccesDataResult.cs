using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccesDataResult<T> : DataResult<T>      //aşağıya 4 tane kullanım versiyonunuda yazdık
    {
        public SuccesDataResult(T data, string message):base(data,true,message)
        {

        }

        public SuccesDataResult(T data):base(data,true)
        {

        }
                                                     //default dataya karşılık gelir
        public SuccesDataResult(string message):base(default,true,message)//bu ve altındakini çok kullanmayız
        {

        }

        public SuccesDataResult():base(default,true)
        {

        }
    }
}
