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

        static void ApplyOptions(DefaultAzureCredentialOptions target, DefaultAzureCredentialOptions source)
        {
            target.ExcludeAzureCliCredential = source.ExcludeAzureCliCredential;
            target.ExcludeAzurePowerShellCredential = source.ExcludeAzurePowerShellCredential;
            target.ExcludeEnvironmentCredential = source.ExcludeEnvironmentCredential;
            target.ExcludeInteractiveBrowserCredential = source.ExcludeInteractiveBrowserCredential;
            target.ExcludeManagedIdentityCredential = source.ExcludeManagedIdentityCredential;
            target.ExcludeSharedTokenCacheCredential = source.ExcludeSharedTokenCacheCredential;
            target.ExcludeVisualStudioCodeCredential = source.ExcludeVisualStudioCodeCredential;
            target.ExcludeVisualStudioCredential = source.ExcludeVisualStudioCredential;
            target.ManagedIdentityClientId = source.ManagedIdentityClientId;
            target.SharedTokenCacheTenantId = source.SharedTokenCacheTenantId;
            target.SharedTokenCacheUsername = source.SharedTokenCacheUsername;
            target.Transport = source.Transport;
            target.AuthorityHost = new Uri(options.Instance);
            target.InteractiveBrowserTenantId = options.TenantId;
            target.VisualStudioTenantId = options.TenantId;
            target.VisualStudioCodeTenantId = options.TenantId;
        }

        /// <summary>
        /// Creates the options for the underlying default credential, given the existing options and those configured by Cogito Azure Identity.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        static DefaultAzureCredentialOptions CreateDefaultOptions(AzureIdentityOptions options, DefaultAzureCredentialOptions source)
        {
            var o = new DefaultAzureCredentialOptions();

            if (source != null)
            {
                o.ExcludeAzureCliCredential = source.ExcludeAzureCliCredential;
                o.ExcludeAzurePowerShellCredential = source.ExcludeAzurePowerShellCredential;
                o.ExcludeEnvironmentCredential = source.ExcludeEnvironmentCredential;
                o.ExcludeInteractiveBrowserCredential = source.ExcludeInteractiveBrowserCredential;
                o.ExcludeManagedIdentityCredential = source.ExcludeManagedIdentityCredential;
                o.ExcludeSharedTokenCacheCredential = source.ExcludeSharedTokenCacheCredential;
                o.ExcludeVisualStudioCodeCredential = source.ExcludeVisualStudioCodeCredential;
                o.ExcludeVisualStudioCredential = source.ExcludeVisualStudioCredential;

                if (source.ManagedIdentityClientId != null)
                    o.ManagedIdentityClientId = source.ManagedIdentityClientId;

                if (source.SharedTokenCacheTenantId != null)
                    o.SharedTokenCacheTenantId = source.SharedTokenCacheTenantId;

                if (source.SharedTokenCacheUsername != null)
                    o.SharedTokenCacheUsername = source.SharedTokenCacheUsername;

                if (source.InteractiveBrowserTenantId != null)
                    o.InteractiveBrowserTenantId = source.InteractiveBrowserTenantId;

                if (source.VisualStudioTenantId != null)
                    o.VisualStudioTenantId = source.VisualStudioTenantId;

                if (source.VisualStudioCodeTenantId != null)
                    o.VisualStudioCodeTenantId = source.VisualStudioCodeTenantId;

                if (source.Transport != null)
                    o.Transport = source.Transport;

                if (source.AuthorityHost != null)
                    o.AuthorityHost = source.AuthorityHost;
            }

            if (options != null)
            {
                if (options.Instance != null)
                    o.AuthorityHost = new Uri(options.Instance);

                if (options.TenantId != null)
                {
                    o.SharedTokenCacheTenantId = options.TenantId;
                    o.InteractiveBrowserTenantId = options.TenantId;
                    o.VisualStudioTenantId = options.TenantId;
                    o.VisualStudioCodeTenantId = options.TenantId;
                }
            }

            return o;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="defaultOptions"></param>
        /// <param name="credential"></param>
        public AzureIdentityCredential(IOptions<AzureIdentityOptions> options, IOptions<DefaultAzureCredentialOptions> defaultOptions, AzureIdentityOptionsCredential credential, DefaultAzureCredential defaultCredential = null) :
            base(credential, defaultCredential ?? new DefaultAzureCredential(CreateDefaultOptions(options.Value, defaultOptions.Value)))
        {

        }

    }

}
