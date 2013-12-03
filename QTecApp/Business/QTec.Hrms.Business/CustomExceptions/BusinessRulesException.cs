namespace QTec.Hrms.Business.CustomExceptions
{
    using System;

    /// <summary>
    /// The business rules exception.
    /// </summary>
    public class BusinessRulesException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRulesException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public BusinessRulesException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRulesException"/> class.
        /// </summary>
        public BusinessRulesException() : base()
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
        public BusinessRulesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}