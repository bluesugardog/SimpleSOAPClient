using SOAPClient.Api.Constants;

namespace SOAPClient.Api.Models.Headers.Oasis.Security
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents the password text
    /// </summary>
    [XmlType("Password",
        Namespace = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssWssecuritySecext10)]
    public class UsernameTokenPasswordText
    {
        /// <summary>
        /// The password type
        /// </summary>
        [XmlAttribute("Type", Namespace = "")]
        public string Type { get; set; }

        /// <summary>
        /// The password value
        /// </summary>
        [XmlText]
        public string Value { get; set; }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public UsernameTokenPasswordText()
        {
            Type = Constant.Namespace.OrgOpenOasisDocsWss200401Oasis200401WssUsernameTokenProfile10PasswordText;
        }
    }
}
