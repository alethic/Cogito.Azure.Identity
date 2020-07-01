using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Cogito.Autofac;

using Microsoft.Extensions.Options;

namespace Cogito.Components.Azure.Identity
{

    /// <summary>
    /// Enables authentication to Azure Active Directory using information provided through Microsoft.Extensions.Configuration options.
    /// </summary>
    [RegisterAs(typeof(AzureIdentityOptionsCredential))]
    public class AzureIdentityOptionsCredential : TokenCredential
    {

        readonly IOptions<AzureIdentityOptions> options;
        readonly TokenCredential credential;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        public AzureIdentityOptionsCredential(IOptions<AzureIdentityOptions> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.credential = BuildCredential();
        }

        /// <summary>
        /// Builds the underlying real credential based on the configuration.
        /// </summary>
        /// <returns></returns>
        TokenCredential BuildCredential()
        {
            if (options.Value.TenantId != null && options.Value.ClientId != null)
                if (options.Value.ClientSecret != null)
                    return new ClientSecretCredential(options.Value.TenantId, options.Value.ClientId, options.Value.ClientSecret);

            return null;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (credential is null)
                throw new AuthenticationFailedException("No configured Azure Identity options.");

            return credential.GetToken(requestContext, cancellationToken);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (credential is null)
                throw new AuthenticationFailedException("No configured Azure Identity options.");

            return credential.GetTokenAsync(requestContext, cancellationToken);
        }

    }

}
