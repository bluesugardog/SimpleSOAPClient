using SOAPClient.Api.Constants;

namespace SOAPClient.Api.Models.Headers.Microsoft
{
    using System.Xml.Serialization;

    /// <summary>
    /// The Microsoft Action SOAP Header
    /// </summary>
    [XmlRoot("Action", Namespace = Constant.Namespace.ComMicrosoftSchemasWs200505AddressingNone)]
    public class ActionSoapHeader : SoapHeader
    {
        /// <summary>
        /// The header action content
        /// </summary>
        [XmlText]
        public string Action { get; set; }
    }
}