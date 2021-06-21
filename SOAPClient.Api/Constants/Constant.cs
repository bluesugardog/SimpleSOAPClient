namespace SOAPClient.Api.Constants
{
    /// <summary>
    /// Class with a wide range of constant values
    /// </summary>
    public static class Constant
    {
        /// <summary>
        /// Namespace constants
        /// </summary>
        public static class Namespace
        {
            /// <summary>
            /// The SOAP Envelope namespace
            /// </summary>
            public const string OrgXmlSoapSchemasSoapEnvelope = 
                "http://schemas.xmlsoap.org/soap/envelope/";

            /// <summary>
            /// The Microsoft addressing namespace
            /// </summary>
            public const string ComMicrosoftSchemasWs200505AddressingNone = 
                "http://schemas.microsoft.com/ws/2005/05/addressing/none";

            /// <summary>
            /// The Oasis Security namespace
            /// </summary>
            public const string OrgOpenOasisDocsWss200401Oasis200401WssWssecuritySecext10 = 
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";

            /// <summary>
            /// The Oasis Security Utilities namespace
            /// </summary>
            public const string OrgOpenOasisDocsWss200401Oasis200401WssWssecurityUtility10 = 
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";

            /// <summary>
            /// 
            /// </summary>
            public const string OrgOpenOasisDocsWss200401Oasis200401WssUsernameTokenProfile10PasswordText = 
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";
        }
    }
}