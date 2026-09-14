# Cogito.Azure.Identity.Autofac

Registers the configured Azure `TokenCredential` in an Autofac container.

## Install

```shell
dotnet add package Cogito.Azure.Identity.Autofac
```

## Use

```csharp
builder.RegisterAllAssemblyModules();
```

`TokenCredential` then resolves from the container, configured from `AzureIdentityOptions`, and the
other `Cogito.Azure.*` packages pick it up without further wiring.

## License

MIT.
