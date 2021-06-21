namespace SOAPClient.Api.Factories
{
    using System.Net.Http;

    /// <summary>
    /// The <see cref="HttpClient"/> factory to be used by <see cref="SoapClient"/>
    /// when no client is provided.
    /// </summary>
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Returns a new <see cref="HttpClient"/> instance.
        /// </summary>
        /// <returns>The HTTP client</returns>
        HttpClient Get();

        /// <summary>
        /// Returns a new <see cref="HttpClient"/> instance that should used
        /// the given <see cref="HttpMessageHandler"/>.
        /// </summary>
        /// <param name="handler">The HTTP message handler</param>
        /// <returns>The HTTP client</returns>
        HttpClient Get(HttpMessageHandler handler);
    }
}