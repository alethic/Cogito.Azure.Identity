using System;

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
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="credential"></param>
        public AzureIdentityCredential(IOptions<AzureIdentityOptions> options, AzureIdentityOptionsCredential credential) :
            base(credential, new DefaultAzureCredential(new DefaultAzureCredentialOptions() { AuthorityHost = new Uri(options.Value.Instance) }))
        {

        }

    }

}
