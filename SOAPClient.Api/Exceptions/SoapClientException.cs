
namespace SOAPClient.Api.Exceptions
{
    using System;

    /// <summary>
    /// Base class for specialized exceptions thrown by the Simple SOAP Client library
    /// </summary>
    public abstract class SoapClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SoapClientException"/>
        /// </summary>
        /// <param name="message">The message to be used</param>
        protected SoapClientException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapClientException"/>
        /// </summary>
        /// <param name="message">The message to be used</param>
        /// <param name="innerException">The inner exception</param>
        protected SoapClientException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
