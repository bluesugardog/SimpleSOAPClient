namespace SOAPClient.Api.Factories
{
    /// <summary>
    /// Creates <see cref="ISoapClient"/> instances
    /// </summary>
    public interface ISoapClientFactory
    {
        /// <summary>
        /// Gets an <see cref="ISoapClient"/>.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <returns></returns>
        TSoapClient Get<TSoapClient>() where TSoapClient : ISoapClient;

        /// <summary>
        /// Indicates to the factory that the given <see cref="ISoapClient"/>
        /// is no longer needed.
        /// </summary>
        /// <param name="client">The SOAP client to release</param>
        void Release(ISoapClient client);
    }
}
