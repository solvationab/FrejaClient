# Solvation Freja client

A basic Freja client maintained by Solvation AB.

## Getting started

Install and register using .AddFrejaClient service collection extension

### Prerequisites

It's required to have Freja certificates.

## Usage

```csharp
var frejaClient = serviceProvider.GetRequiredService<IFrejaClient>();
var response = await frejaClient.Authenticate();
```

## Additional documentation

- [Freja documentation](https://frejaeid.atlassian.net/wiki/spaces/DOC/overview)
- [Freja developers](https://org.frejaeid.com/for-utvecklare/)]
- [Freja](https://www.freja.se/)

## Feedback

https://github.com/solvationab/FrejaClient
