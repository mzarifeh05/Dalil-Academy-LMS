using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Exceptions
{
    public class NotFoundException(string message) : Exception(message);
    public class ConflictException(string message) : Exception(message);
}
