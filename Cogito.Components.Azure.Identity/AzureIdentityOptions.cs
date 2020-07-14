using Cogito.Extensions.Options.Configuration.Autofac;

namespace Cogito.Components.Azure.Identity
{

    /// <summary>
    /// Describes the required Azure identity configuration.
    /// </summary>
    [RegisterOptions("Cogito:Components:Azure:Identity")]
    [RegisterOptions("AzureAd")]
    public class AzureIdentityOptions
    {

        /// <summary>
        /// Instance of the Azure login service.
        /// </summary>
        public string Instance { get; set; } = "https://login.microsoftonline.com";

        /// <summary>
        /// ID of the Azure tenant.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Application client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Application client secret.
        /// </summary>
        public string ClientSecret { get; set; }

    }

}
