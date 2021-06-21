namespace SOAPClient.Api.Factories
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using Exceptions;
    using Models;

    /// <summary>
    /// Provider for serialization and deserialization of <see cref="SoapEnvelope"/> instances.
    /// </summary>
    public class SoapEnvelopeSerializationProvider : ISoapEnvelopeSerializationProvider
    {
        private XmlWriterSettings _xmlWriterSettings;
        private XmlSerializerNamespaces _xmlSerializerNamespaces;

        /// <summary>
        /// XML writer settings to be used when serializing <see cref="SoapEnvelope"/>
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public XmlWriterSettings XmlWriterSettings
        {
            get { return _xmlWriterSettings; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _xmlWriterSettings = value;
            }
        }

        /// <summary>
        /// XML serializer namespaces to be used when serializing <see cref="SoapEnvelope"/>
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public XmlSerializerNamespaces XmlSerializerNamespaces
        {
            get { return _xmlSerializerNamespaces; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _xmlSerializerNamespaces = value;
            }
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public SoapEnvelopeSerializationProvider()
        {
            _xmlWriterSettings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = false,
                NamespaceHandling = NamespaceHandling.OmitDuplicates
            };

            _xmlSerializerNamespaces = new XmlSerializerNamespaces();
            _xmlSerializerNamespaces.Add("", "");
        }

        #region Implementation of ISoapEnvelopeSerializationProvider

        /// <summary>
        /// Serializes a given <see cref="SoapEnvelope"/> instance into a XML string.
        /// </summary>
        /// <param name="envelope">The instance to serialize</param>
        /// <returns>The resulting XML string</returns>
        public string ToXmlString(SoapEnvelope envelope)
        {
            if (envelope == null) return null;

            try
            {
                using (var textWriter = new StringWriter())
                using (var xmlWriter = XmlWriter.Create(textWriter, XmlWriterSettings))
                {
                    new XmlSerializer(typeof(SoapEnvelope))
                        .Serialize(xmlWriter, envelope, XmlSerializerNamespaces);
                    return textWriter.ToString();
                }
            }
            catch (Exception e)
            {
                throw new SoapEnvelopeSerializationException(envelope, e);
            }
        }

        /// <summary>
        /// Deserializes a given XML string into a <see cref="SoapEnvelope"/>.
        /// </summary>
        /// <param name="xml">The XML string do deserialize</param>
        /// <returns>The resulting <see cref="SoapEnvelope"/></returns>
        public SoapEnvelope ToSoapEnvelope(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return null;

            try
            {
                using (var textWriter = new StringReader(xml))
                {
                    var result = (SoapEnvelope)new XmlSerializer(typeof(SoapEnvelope)).Deserialize(textWriter);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new SoapEnvelopeDeserializationException(xml, e);
            }
        }

        #endregion
    }
}