using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

                                                  //this burada Result demek   
        public Result(bool succes, string message):this(succes)//:this(succes) 16.satırdaki ctorun çalışmasını sağlar
        {
            Message = message;
        }

        public Result(bool succes)
        {
            Succes = succes;
        }

        public bool Succes { get; }

        public string Message { get; }
    }
}
