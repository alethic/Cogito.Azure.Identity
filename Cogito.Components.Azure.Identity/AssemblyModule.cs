using Autofac;

using Cogito.Autofac;

namespace Cogito.Components.Azure.Identity
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
        }

    }

}
