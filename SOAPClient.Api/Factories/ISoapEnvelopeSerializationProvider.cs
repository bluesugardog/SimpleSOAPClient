namespace SOAPClient.Api.Factories
{
    using Models;

    /// <summary>
    /// Provider for serialization and deserialization of <see cref="SoapEnvelope"/> instances.
    /// </summary>
    public interface ISoapEnvelopeSerializationProvider
    {
        /// <summary>
        /// Serializes a given <see cref="SoapEnvelope"/> instance into a XML string.
        /// </summary>
        /// <param name="envelope">The instance to serialize</param>
        /// <returns>The resulting XML string</returns>
        string ToXmlString(SoapEnvelope envelope);

        /// <summary>
        /// Deserializes a given XML string into a <see cref="SoapEnvelope"/>.
        /// </summary>
        /// <param name="xml">The XML string do deserialize</param>
        /// <returns>The resulting <see cref="SoapEnvelope"/></returns>
        SoapEnvelope ToSoapEnvelope(string xml);
    }
}
