using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disc.Domain.Exceptions.ConditionExceptions
{
    public class InvalidConditionException : Exception
    {
        public InvalidConditionException(string condition)
            : base($"Invalid condition: {condition}")
        {
        }

        public InvalidConditionException(string condition, string message)
            : base($"Invalid condition: {condition}. {message}")
        {
        }

        public InvalidConditionException(string condition, string message, Exception innerException)
            : base($"Invalid condition: {condition}. {message}", innerException)
        {
        }
    }
}
