using Autofac;

using Cogito.Autofac;
using Cogito.Extensions.Options.Configuration.Autofac;

namespace Cogito.Azure.Identity.Autofac
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<Cogito.Extensions.Options.Configuration.Autofac.AssemblyModule>();
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.Configure<AzureIdentityOptions>("AzureAd");
            builder.RegisterType<AzureIdentityOptionsCredential>().AsSelf();
            builder.RegisterType<AzureIdentityCredential>().AsSelf();
        }

    }

}
