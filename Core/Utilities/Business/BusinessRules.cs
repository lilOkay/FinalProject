using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {//logic iş kuralı demektir
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Succes)//parametre ile gönderdiğimiz iş kurallarında hatalı olanı businessa bilgilendir
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
