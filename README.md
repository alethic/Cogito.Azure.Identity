# Cogito.Azure.Identity

[![Build](https://github.com/alethic/Cogito.Azure.Identity/actions/workflows/Cogito.Azure.Identity.yml/badge.svg)](https://github.com/alethic/Cogito.Azure.Identity/actions/workflows/Cogito.Azure.Identity.yml)

Supplies an Azure TokenCredential from configuration, so which identity a service uses is a deployment decision.

## Packages

**[Cogito.Azure.Identity](https://www.nuget.org/packages/Cogito.Azure.Identity)** — Supplies an Azure `TokenCredential` from configuration, so the credential an application uses is a deployment decision rather than a code one.

**[Cogito.Azure.Identity.Autofac](https://www.nuget.org/packages/Cogito.Azure.Identity.Autofac)** — Registers the configured Azure `TokenCredential` in an Autofac container.

Each package carries its own README with the detail; the links above go to nuget.org.

## Building

```shell
dotnet restore Cogito.Azure.Identity.sln
dotnet msbuild -p:Configuration=Release Cogito.Azure.Identity.dist.msbuildproj
```

Packages are staged into `dist/nuget` and test suites into `dist/tests`; run a suite with
`dotnet test -f <tfm> <path to its assembly>`.

## License

MIT — see [LICENSE](LICENSE).
