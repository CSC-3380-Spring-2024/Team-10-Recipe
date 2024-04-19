# Team-10

### Client URL:
[http://localhost:5155/](http://localhost:5155/)

### API URL:
[http://localhost:5123/swagger/index.html](http://localhost:5123/swagger/index.html)

## Instructions to Run:

1. Install the .Net 8 sdk [microsoft install link](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. `cd Team-10-Recipe`
3. `dotnet build`
4. Open a new terminal
5. In one terminal, run `cd Recipe_Proj`
6. In the other terminal, run `cd Recipe_Proj.Server`
7. Execute `dotnet run` in both terminals
8. Open [http://localhost:5155](http://localhost:5155) in your browser


### Note to Alex:

Stupid Sqltools extension path:
/Users/myusername/Library/Application Support/vscode-sqltools

change package-lock.json line 4 requires to false

might need to do the same to Team-10-Recipe/package-lock.json as well