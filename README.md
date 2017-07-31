[![Build status](https://ci.appveyor.com/api/projects/status/t415a7gmtr1opask/branch/master?svg=true)](https://ci.appveyor.com/project/CollectorHeimdal/serilog-enrichers-author/branch/master)
# serilog-enrichers-author

Includes the serilog enricher AuthorEnricher that will add an "Author" object to each log message.
The author object contains four properties:
* Team (e.g. "Heimdal" or "Ace of Space")
* Department (e.g. "Payments" or "Solutions")
* _(Optional)_ ServiceGroup (If this service is part of a larger group of services, then the name of that group, e.g. "Edge" or "Loans")
* _(Optional)_ Repository (The url to where the source code can be found)
 

Use it like this:
```csharp
var logger = new LoggerConfiguration()
                 .Enrich.With(new AuthorEnricher(
                                    teamName: "Heimdal", 
                                    department: "Payments", 
                                    serviceGroup: "Edge",
                                    repositoryUrl: new Uri("https://github.com/collector-bank/serilog-enrichers-author")))
                 .CreateLogger();
```