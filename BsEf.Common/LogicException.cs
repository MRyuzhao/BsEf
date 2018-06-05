using System;

namespace BsEf.Common
{
    public class LogicException : Exception
    {
        public LogicException(string message) : base(message)
        {
        }
    }
}