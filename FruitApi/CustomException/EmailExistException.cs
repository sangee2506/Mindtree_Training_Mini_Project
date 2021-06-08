﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.CustomException
{
    public class EmailExistException : Exception
    {
        public EmailExistException(string message) : base(message)
        {
        }
    }
}
