namespace SOAPClient.Api.Models.Headers
{
    using System;
    using Microsoft;
    using Oasis.Security;

    /// <summary>
    /// Class with known <see cref="SoapHeader"/> builder methods.
    /// </summary>
    public static class KnownHeader
    {
        /// <summary>
        /// Class with Microsoft specific <see cref="SoapHeader"/> builder methods.
        /// </summary>
        public static class Microsoft
        {
            /// <summary>
            /// Creates a new Microsoft Action SOAP Header.
            /// </summary>
            /// <param name="action">The action for the header</param>
            /// <param name="mustUnderstand">Does the server must understand the header?</param>
            /// <returns>The new <see cref="ActionSoapHeader"/></returns>
            public static ActionSoapHeader Action(string action, bool mustUnderstand = true)
            {
                return new ActionSoapHeader
                {
                    Action = action,
                    MustUnderstand = mustUnderstand ? 1 : 0
                };
            }

            /// <summary>
            /// Creates a new Microsoft To SOAP Header.
            /// </summary>
            /// <param name="to">The action for the header</param>
            /// <param name="mustUnderstand">Does the server must understand the header?</param>
            /// <returns>The new <see cref="ToSoapHeader"/></returns>
            public static ToSoapHeader To(string to, bool mustUnderstand = true)
            {
                return new ToSoapHeader
                {
                    To = to,
                    MustUnderstand = mustUnderstand ? 1 : 0
                };
            }
        }

        /// <summary>
        /// Class with Oasis specific <see cref="SoapHeader"/> builder methods.
        /// </summary>
        public static class Oasis
        {
            /// <summary>
            /// Class with Oasis Security specific <see cref="SoapHeader"/> builder methods.
            /// </summary>
            public static class Security
            {
                /// <summary>
                /// Creates a new Oasis Security Username Token with password text SOAP header.
                /// </summary>
                /// <param name="username">The username</param>
                /// <param name="password">The password</param>
                /// <param name="mustUnderstand">Does the server must understand the header?</param>
                /// <returns>The new <see cref="UsernameTokenAndPasswordTextSoapHeader"/></returns>
                public static UsernameTokenAndPasswordTextSoapHeader UsernameTokenAndPasswordText(
                    string username, string password, bool mustUnderstand = true)
                {
                    var randomId = Guid.NewGuid().ToString("N");

                    return new UsernameTokenAndPasswordTextSoapHeader
                    {
                        Timestamp = new Timestamp
                        {
                            Id = string.Concat("_TS", randomId),
                            Created = DateTime.UtcNow,
                            Expires = DateTime.UtcNow.AddMinutes(15)
                        },
                        UsernameToken = new UsernameTokenWithPasswordText
                        {
                            Id = string.Concat("_UT", randomId),
                            Username = username,
                            Password = new UsernameTokenPasswordText
                            {
                                Value = password
                            }
                        },
                        MustUnderstand = mustUnderstand ? 1 : 0
                    };
                }
            }
        }
    }
}
