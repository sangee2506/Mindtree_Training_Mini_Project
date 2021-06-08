using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.CustomException
{
    public class NullValuesException : Exception
    {
        public NullValuesException(string message) : base(message)
        {
        }
    }
}
