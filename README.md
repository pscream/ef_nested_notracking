# ef_nested_notracking
Entity Framework: strange behavior when using Skip(), Take() along with AsNoTracking(). Nested models disappear when use Skip() and/or Take() plus AsNoTracking(). Any of them work fine in its own.
Persistence of a nested entity: works for updating, doesn't work for insertion

Before starting the application, get the database ready:

1. Drop the existing database (optional)
```
PS> cd script
PS> .\drop-database.ps1
```
If you get an error 'Cannot drop database "CheckNestedNull" because it is currently in use.' Delete the 'CheckNestedNull' manually with SQL Server Management Studio.

2. Initialize a new one
```
PS> cd script
PS> .\init-database.ps1
```
