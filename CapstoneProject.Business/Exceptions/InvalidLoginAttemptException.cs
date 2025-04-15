﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Business.Exceptions
{
    public class InvalidLoginAttemptException : Exception
    {
        public InvalidLoginAttemptException() : base() { }
        public InvalidLoginAttemptException(string message) : base(message) { }
        public InvalidLoginAttemptException(string message, Exception innerException) : base(message, innerException) { }
    }
}