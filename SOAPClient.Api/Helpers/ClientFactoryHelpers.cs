
namespace SOAPClient.Api.Helpers
{
	using SOAPClient.Api.Factories;
	using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper methods for working with <see cref="ISoapClientFactory"/> instances.
    /// </summary>
    public static class ClientFactoryHelpers
    {
        #region Sync

        /// <summary>
        /// Gets a <see cref="ISoapClient"/> instance from the factory and releases 
        /// when the action completes.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="factory">The factory to use</param>
        /// <param name="action">The action to execute</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void GetAndRelease<TSoapClient>(this ISoapClientFactory factory, Action<TSoapClient> action)
            where TSoapClient : ISoapClient
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var client = factory.Get<TSoapClient>();
            try
            {
                action(client);
            }
            finally
            {
                factory.Release(client);
            }
        }

        /// <summary>
        /// Gets a <see cref="ISoapClient"/> instance from the factory and releases 
        /// when the action completes.
        /// </summary>
        /// <param name="factory">The factory to use</param>
        /// <param name="action">The action to execute</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void GetAndRelease(this ISoapClientFactory factory, Action<SoapClient> action)
        {
            GetAndRelease<SoapClient>(factory, action);
        }

        /// <summary>
        /// Gets a <see cref="ISoapClient"/> instance from the factory and releases 
        /// when the action completes.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="factory">The factory to use</param>
        /// <param name="action">The action to execute</param>
        /// <returns>The action result</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TResult GetAndRelease<TSoapClient, TResult>(this ISoapClientFactory factory, Func<TSoapClient, TResult> action)
            where TSoapClient : ISoapClient
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var client = factory.Get<TSoapClient>();
            try
            {
                return action(client);
            }
            finally
            {
                factory.Release(client);
            }
        }

        /// <summary>
        /// Gets a <see cref="ISoapClient"/> instance from the factory and releases 
        /// when the action completes.
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="factory">The factory to use</param>
        /// <param name="action">The action to execute</param>
        /// <returns>The action result</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TResult GetAndRelease<TResult>(this ISoapClientFactory factory, Func<SoapClient, TResult> action)
        {
            return GetAndRelease<SoapClient, TResult>(factory, action);
        }

        #endregion

        #region Async

        /// <summary>
        /// Gets a <see cref="ISoapClient"/> instance from the factory and releases 
        /// when the action completes.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <param name="factory">The factory to use</param>
        /// <param name="action">The action to execute</param>
        /// <param name="ct">The cancelattion token</param>
        /// <returns>A task that can be awaited</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task GetAndReleaseAsync<TSoapClient>(
            this ISoapClientFactory factory, Func<TSoapClient, CancellationToken, Task> action, CancellationToken ct = default(CancellationToken))
            where TSoapClient : ISoapClient
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var client = factory.Get<TSoapClient>();
            try
            {
                await action(client, ct).ConfigureAwait(false);
            }
            finally
            {
                factory.Release(client);
            }
        }

        /// <summary>
        /// Gets a <see cref="ISoapClient"/> instance from the factory and releases 
        /// when the action completes.
        /// </summary>
        /// <param name="factory">The factory to use</param>
        /// <param name="action">The action to execute</param>
        /// <param name="ct">The cancelattion token</param>
        /// <returns>A task that can be awaited</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task GetAndReleaseAsync(
            this ISoapClientFactory factory, Func<SoapClient, CancellationToken, Task> action, CancellationToken ct = default(CancellationToken))
        {
            await GetAndReleaseAsync<SoapClient>(factory, action, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a <see cref="ISoapClient"/> instance from the factory and releases 
        /// when the action completes.
        /// </summary>
        /// <typeparam name="TSoapClient">The SOAP client type</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="factory">The factory to use</param>
        /// <param name="action">The action to execute</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task that can be awaited for the result</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<TResult> GetAndReleaseAsync<TSoapClient, TResult>(
            this ISoapClientFactory factory, Func<TSoapClient, CancellationToken, Task<TResult>> action, CancellationToken ct = default(CancellationToken))
            where TSoapClient : ISoapClient
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var client = factory.Get<TSoapClient>();
            try
            {
                return await action(client, ct).ConfigureAwait(false);
            }
            finally
            {
                factory.Release(client);
            }
        }

        /// <summary>
        /// Gets a <see cref="ISoapClient"/> instance from the factory and releases 
        /// when the action completes.
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="factory">The factory to use</param>
        /// <param name="action">The action to execute</param>
        /// <param name="ct">The cancellation token</param>
        /// <returns>A task that can be awaited for the result</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<TResult> GetAndReleaseAsync<TResult>(
            this ISoapClientFactory factory, Func<SoapClient, CancellationToken, Task<TResult>> action, CancellationToken ct = default(CancellationToken))
        {
            return await GetAndReleaseAsync<SoapClient, TResult>(factory, action, ct).ConfigureAwait(false);
        }

        #endregion
    }
}
