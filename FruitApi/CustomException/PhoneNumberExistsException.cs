using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.CustomException
{
    public class PhoneNumberExistsException : Exception
    {
        public PhoneNumberExistsException(string message) : base(message)
        {
        }
    }
}
