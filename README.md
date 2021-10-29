# [exchangerate.host](https://exchangerate.host/) C# appliaction

This is a sample application that connects to exchange rate API and returns the result in the desired format.
## Getting Started
In Visual Studio, clone the repository and build it.
## Settings
A few settings are available in `appsettings.json` file

- **WebDataProviderBaseUri**: Base address of exchange rate API (default: "https://api.exchangerate.host/")
- **CurrencySplitChar**: The character used to split currency pairs (default: "->")
## Swagger
Use swagger to explore available endpoints: https://localhost:44337/swagger/
## Endpoints with sample query
- https://localhost:44337/Exchange/2018-02-01,2018-02-15,2018-03-01/SEK->NOK
- https://localhost:44337/Exchange/2018-02-01,2018-02-15,2018-03-01,2020-04-01/SEK/USD
## Validation
There is currently no validation in place.

Input data is not validated, and if it is malformed, the system will throw an exception.
## Authentication
Authentication is not implemented at this time.
