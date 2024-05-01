# Team-10

### Client URL:
[localhost:5155/](http://localhost:5155/)

### API URL:
[localhost:5123/swagger/index.html](http://localhost:5123/swagger/index.html)

## Instructions to Run:

1. Install the .NET 8 sdk [microsoft install link](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. Install EF Core cli
    ```sh 
    dotnet tool install --global dotnet-ef
    ```
3. ```sh
    cd Team-10-Recipe
    ```
4. ```sh
    dotnet build
    ```
5. Open a new terminal
6. In one terminal, run:
    ```sh
    cd Recipe_Proj
    ```
7. In the other terminal, run:
    ```sh
    cd Recipe_Proj.Server
    ```
8. In both terminals, execute:
    ```sh
    dotnet run
    ```
9. Open [localhost:5155](http://localhost:5155) in your browser