using SOAPClient.Api.Constants;

namespace SOAPClient.Api.Models.Headers.Oasis.Security
{
    using System.Xml.Serialization;

    /// <summary>
    /// The SOAP Security header for username and text passwords
    /// </summary>
    [XmlRoot("Security",
        Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecuritySecext10)]
    public class UsernameTokenAndPasswordTextSoapHeader : SecuritySoapHeader
    {
        /// <summary>
        /// The username token
        /// </summary>
        [XmlElement("UsernameToken",
            Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecuritySecext10)]
        public UsernameTokenWithPasswordText UsernameToken { get; set; }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public UsernameTokenAndPasswordTextSoapHeader()
        {
            MustUnderstand = 1;
        }
    }
}
