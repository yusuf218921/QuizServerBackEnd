using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.BusinessRules
{
    // İş kurallarını uygulayan Utility sınıfı
    public class BusinessRules
    {
        // İş kurallarının sağlanığ sağlanmadığının testi
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return logic;
            }
            return null;
        }
    }
}