﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string? message)
            :base(message) { }

        public EntityNotFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
