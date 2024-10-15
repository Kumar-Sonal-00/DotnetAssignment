using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuiceShopExceptions
{
    public class JuiceIdException : Exception
    {
        //TODO

        // Default constructor
        public JuiceIdException() : base("Invalid juice id, please check your input")
        {
        }

        // Constructor that accepts a custom message
        public JuiceIdException(string message) : base(message)
        {
        }

        // Constructor that accepts a custom message and an inner exception
        public JuiceIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
