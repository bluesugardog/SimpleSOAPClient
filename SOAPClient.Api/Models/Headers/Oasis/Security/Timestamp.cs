using SOAPClient.Api.Constants;

namespace SOAPClient.Api.Models.Headers.Oasis.Security
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a SOAP Security timestamp
    /// </summary>
    [XmlType("Timestamp",
        Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecurityUtility10)]
    public class Timestamp
    {
        /// <summary>
        /// The timestamp id
        /// </summary>
        [XmlAttribute("Id",
            Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecurityUtility10)]
        public string Id { get; set; }

        /// <summary>
        /// The date and time when the timestamp was created
        /// </summary>
        [XmlElement("Created",
            Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecurityUtility10)]
        public DateTime Created { get; set; }

        /// <summary>
        /// The date and time when the timestamp expired
        /// </summary>
        [XmlElement("Expires",
            Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecurityUtility10)]
        public DateTime Expires { get; set; }
    }
}
