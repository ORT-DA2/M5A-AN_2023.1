﻿using System;
namespace Uyflix.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException() : base()
        {

        }

        public BusinessLogicException(string message) : base(message)
        {

        }

        public BusinessLogicException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
