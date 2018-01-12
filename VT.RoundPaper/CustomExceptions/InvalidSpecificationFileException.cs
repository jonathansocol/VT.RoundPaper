using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VT.RoundPaper.CustomExceptions
{
    public class InvalidSpecificationFileException : Exception
    {
        public InvalidSpecificationFileException()
        {
        }

        public InvalidSpecificationFileException(string message) : base(message)
        {
        }

        public InvalidSpecificationFileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSpecificationFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
