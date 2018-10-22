# Navis.SDK.CompanyCloud
This project is a C# wrapper of the Navis Company Cloud REST API. It is used to easily query and modify Account entities in C#
## Basic usage
This example explains how to query ships.
Install the package from nuget.org:

```
Install-Package Navis.SDK.CompanyCloud
```

Create the ship client and insert a `TokenProvider` and `NcsSettings`:

```
var client = new ShipClient(tokenProvider, ncsSettings);
```

Query ship with a specific IMO Number:

```
var imoNumber = ...;
var cancellationToken = ...;
var ship = await client.GetByIdAsync(imoNumber, cancellationToken);
```

## Clients

The package contains one client for each API resource. Each client contains methods to GET, POST, PUT and DELETE resources according to the API specification: <https://api.company.navis-cvs.com>

* AccountMembershipClient
* ShipAssociationClient
* ShipClient