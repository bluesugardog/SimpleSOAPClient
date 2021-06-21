
namespace SOAPClient.Api.Exceptions
{
    using System;
    using Models;

    /// <summary>
    /// Exception thrown when an exception is thrown when deserializing
    /// a given XML string to a <see cref="SoapEnvelope"/>.
    /// </summary>
    public class SoapEnvelopeDeserializationException : SoapClientException
    {
        private const string DefaultErrorMessage = "Failed to deserialize the XML string to a SOAP Envelope";

        /// <summary>
        /// The XML string that was beeing deserialized
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        public string XmlValue { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapEnvelopeDeserializationException"/>
        /// </summary>
        /// <param name="xmlValue">The XML string that was beeing deserialized</param>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelopeDeserializationException(string xmlValue) : this(xmlValue, DefaultErrorMessage)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapEnvelopeDeserializationException"/>
        /// </summary>
        /// <param name="xmlValue">The XML string that was beeing deserialized</param>
        /// <param name="message">The message to be used</param>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelopeDeserializationException(string xmlValue, string message) : base(message)
        {
            if (xmlValue == null) throw new ArgumentNullException(nameof(xmlValue));

            XmlValue = xmlValue;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapEnvelopeDeserializationException"/>
        /// </summary>
        /// <param name="xmlValue">The XML string that was beeing deserialized</param>
        /// <param name="message">The message to be used</param>
        /// <param name="innerException">The inner exception</param>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelopeDeserializationException(string xmlValue, string message, Exception innerException) : base(message, innerException)
        {
            if (xmlValue == null) throw new ArgumentNullException(nameof(xmlValue));

            XmlValue = xmlValue;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapEnvelopeDeserializationException"/>
        /// </summary>
        /// <param name="xmlValue">The XML string that was beeing deserialized</param>
        /// <param name="innerException">The inner exception</param>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelopeDeserializationException(string xmlValue, Exception innerException) : this(xmlValue, DefaultErrorMessage, innerException)
        {

        }
    }
}