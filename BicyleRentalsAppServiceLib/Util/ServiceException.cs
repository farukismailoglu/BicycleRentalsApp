﻿using System;

namespace BicyleRentalsApp.Util
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {

        }
        public ServiceException(string msg) : base(msg)
        {

        }
        public ServiceException(string msg, Exception innerException) : base(msg, innerException)
        {

        }
        public override string Message
        {
            get
            {
                var innerText = InnerException != null ?", Inner Message:"+InnerException.Message : "";
                return $"Message:{base.Message}{innerText}";
            }
        }
    }
}
