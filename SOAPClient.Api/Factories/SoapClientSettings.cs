namespace SOAPClient.Api.Factories
{
    using System;

    /// <summary>
    /// Represents settings to be used by SOAP clients
    /// </summary>
    public sealed class SoapClientSettings
    {
        #region Statics

        private static SoapClientSettings _default;

        /// <summary>
        /// The default <see cref="SoapClientSettings"/> to be used.
        /// </summary>
        public static SoapClientSettings Default
        {
            get { return _default; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _default = value;
            }
        }

        static SoapClientSettings()
        {
            _default = new SoapClientSettings();
        }

        #endregion

        private ISoapEnvelopeSerializationProvider _serializationProvider;
        private IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// The SOAP Envelope serialization provider
        /// </summary>
        public ISoapEnvelopeSerializationProvider SerializationProvider
        {
            get { return _serializationProvider; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _serializationProvider = value;
            }
        }

        /// <summary>
        /// The HTTP client factory
        /// </summary>
        public IHttpClientFactory HttpClientFactory
        {
            get { return _httpClientFactory; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _httpClientFactory = value;
            }
        }

        /// <summary>
        /// Creates a new instance with default values
        /// </summary>
        public SoapClientSettings()
        {
            _serializationProvider = new SoapEnvelopeSerializationProvider();
            _httpClientFactory = new HttpClientFactory();
        }
    }
}
