using Azure.Core;
using Azure.Identity;

using Cogito.Autofac;

using Microsoft.Extensions.Options;

namespace Cogito.Components.Azure.Identity
{

    /// <summary>
    /// Provides a <see cref="TokenCredential"/> that supports reading values from all the default sources.
    /// </summary>
    [RegisterAs(typeof(AzureIdentityCredential))]
    public class AzureIdentityCredential : ChainedTokenCredential
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="credential"></param>
        public AzureIdentityCredential(IOptions<AzureIdentityOptions> options, AzureIdentityOptionsCredential credential) :
            base(credential, new DefaultAzureCredential(new DefaultAzureCredentialOptions() { AuthorityHost = options.Value.Authority }))
        {

        }

    }

}
