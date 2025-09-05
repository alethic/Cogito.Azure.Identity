using System.Collections.Generic;
using System.Linq;

using Azure.Core;
using Azure.Identity;

using Microsoft.Extensions.Options;

namespace Cogito.Azure.Identity
{

    /// <summary>
    /// Provides a <see cref="TokenCredential"/> that supports reading values from all the default sources.
    /// </summary>
    public class AzureIdentityCredential : ChainedTokenCredential
    {

        /// <summary>
        /// Iterates the authentication methods to attempt.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultCredential"></param>
        /// <returns></returns>
        static IEnumerable<TokenCredential> CreateClientSecretCredentials(AzureIdentityOptions value, DefaultAzureCredential? defaultCredential)
        {
            // specified values, attempt secret first
            if (value.ClientSecret != null && value.ClientId != null)
                yield return new ClientSecretCredential(value.TenantId, value.ClientId, value.ClientSecret);

            // include default credential
            yield return defaultCredential ?? new DefaultAzureCredential();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        public AzureIdentityCredential(IOptions<AzureIdentityOptions> options, DefaultAzureCredential? defaultCredential = null) :
            base(CreateClientSecretCredentials(options.Value, defaultCredential).ToArray())
        {

        }

    }

}
