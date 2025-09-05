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
        /// Creates the options for the underlying default credential, given the existing options and those configured by Cogito Azure Identity.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        static DefaultAzureCredentialOptions CreateDefaultOptions(AzureIdentityOptions options, DefaultAzureCredentialOptions source)
        {
            return source ?? new DefaultAzureCredentialOptions();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="credential"></param>
        public AzureIdentityCredential(IOptions<AzureIdentityOptions> options, IOptions<DefaultAzureCredentialOptions> defaultOptions, AzureIdentityOptionsCredential credential, DefaultAzureCredential defaultCredential = null) :
            base(credential, new DefaultAzureCredential(CreateDefaultOptions(options.Value, defaultOptions.Value)))
        {

        }

    }

}
