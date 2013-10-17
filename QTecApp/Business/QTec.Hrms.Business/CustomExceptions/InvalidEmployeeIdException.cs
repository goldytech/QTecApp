using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTec.Hrms.Business.CustomExceptions
{
    public class InvalidEmployeeIdException :Exception
    {
        public InvalidEmployeeIdException(string message)
            :base(message)
        {
            
        }

        public InvalidEmployeeIdException()
            :base()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEmployeeIdException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public InvalidEmployeeIdException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
