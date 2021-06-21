using SOAPClient.Api.Constants;

namespace SOAPClient.Api.Models.Headers.Oasis.Security
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents an username token with a password text
    /// </summary>
    [XmlType("UsernameToken",
        Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecuritySecext10)]
    public class UsernameTokenWithPasswordText
    {
        /// <summary>
        /// The token id
        /// </summary>
        [XmlAttribute("Id",
            Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecurityUtility10)]
        public string Id { get; set; }

        /// <summary>
        /// The username value
        /// </summary>
        [XmlElement("Username",
            Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecuritySecext10)]
        public string Username { get; set; }

        /// <summary>
        /// The password element
        /// </summary>
        [XmlElement("Password",
            Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecuritySecext10)]
        public UsernameTokenPasswordText Password { get; set; }
    }
}
