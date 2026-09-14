# Cogito.Azure.Identity

Supplies an Azure `TokenCredential` from configuration, so the credential an application uses is a
deployment decision rather than a code one.

## Why

`DefaultAzureCredential` is convenient but opaque: it tries a chain of sources and you find out which
one answered at runtime. When a service has to use a specific managed identity, or developers need a
different credential locally than in production, you want that stated in configuration.

## Install

```shell
dotnet add package Cogito.Azure.Identity
```

## Use

Bind `AzureIdentityOptions` from configuration and take `AzureIdentityCredential` where a
`TokenCredential` is wanted:

```json
{
  "Azure": {
    "Identity": {
      "TenantId": "...",
      "ClientId": "..."
    }
  }
}
```

The credential is a normal `TokenCredential`, so it goes straight into any Azure SDK client.

See `Cogito.Azure.Identity.Autofac` to have it registered for you.

## License

MIT.
