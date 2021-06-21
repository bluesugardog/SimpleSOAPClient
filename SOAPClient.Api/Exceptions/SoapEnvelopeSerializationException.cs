
namespace SOAPClient.Api.Exceptions
{
    using System;
    using Models;

    /// <summary>
    /// Exception thrown when an exception is thrown when serializing
    /// a given <see cref="SoapEnvelope"/> to a XML string.
    /// </summary>
    public class SoapEnvelopeSerializationException : SoapClientException
    {
        private const string DefaultErrorMessage = "Failed to serialize the SOAP Envelope";

        /// <summary>
        /// The <see cref="SoapEnvelope"/> that failed to be serialized
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelope Envelope { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapEnvelopeSerializationException"/>
        /// </summary>
        /// <param name="envelope">The envelope that failed to serialize</param>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelopeSerializationException(SoapEnvelope envelope) : this(envelope, DefaultErrorMessage)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapEnvelopeSerializationException"/>
        /// </summary>
        /// <param name="envelope">The envelope that failed to serialize</param>
        /// <param name="message">The message to be used</param>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelopeSerializationException(SoapEnvelope envelope, string message) : base(message)
        {
            if (envelope == null) throw new ArgumentNullException(nameof(envelope));

            Envelope = envelope;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapEnvelopeSerializationException"/>
        /// </summary>
        /// <param name="envelope">The envelope that failed to serialize</param>
        /// <param name="message">The message to be used</param>
        /// <param name="innerException">The inner exception</param>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelopeSerializationException(SoapEnvelope envelope, string message, Exception innerException) : base(message, innerException)
        {
            if (envelope == null) throw new ArgumentNullException(nameof(envelope));

            Envelope = envelope;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SoapEnvelopeSerializationException"/>
        /// </summary>
        /// <param name="envelope">The envelope that failed to serialize</param>
        /// <param name="innerException">The inner exception</param>
        /// <exception cref="ArgumentNullException"/>
        public SoapEnvelopeSerializationException(SoapEnvelope envelope, Exception innerException) : this(envelope, DefaultErrorMessage, innerException)
        {

        }
    }
}