# Technologies
- C#
- ASP.NET
- XUnit
- Moq

# Description
A simple ASP.NET API to act as the backend for the [ContosoPizzaWeb](https://github.com/sam-higgins-portfolio/ContosoPizzaWeb) project.

# Running

Runs on http://localhost:5020

```
dotnet run
```

# Testing

```
dotnet test
```

# Development

1. Created shell project using:

ContosoPizzaAPI
```csharp
dotnet new ContosoPizzaAPI -controllers -f net9.0
```
ContosoPizzaAPITests
```csharp
dotnet new xunit -n ContosoPizzaAPITests
```
Added both to the solution
```csharp
dotnet new sln --name ContosoPizzaAPI
dotnet sln add .\ContosoPizzaAPI\ContosoPizzaAPI.csproj
dotnet sln add .\ContosoPizzaAPITest\ContosoPizzaAPITest.csproj
``` 
Added reference to Test Project
```csharp
dotnet add .\ContosoPizzaAPITest\ContosoPizzaAPITest.csproj reference .\ContosoPizzaAPI\ContosoPizzaAPI.csproj
```
Added Moq library
```csharp
dotnet add .\ContosoPizzaAPITest\ContosoPizzaAPITest.csproj package Moq 
```

2. Added new Model, Controller and Service for Pizza functionality.

3. Added CORs policy to allow connectivity from Front End (ContosoPizzaWeb):
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowContosoWeb", policy =>
    {
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    }); 
});

app.UseCors("AllowContosoWeb");
```

4. Adopted Repository Pattern for storage.
    - *Note: This could be considered over engineered for this project, but it offers better decoupling should I want to extend later to other storage options.*

5. Added unit tests.
    - *Note: Due to the repository pattern and simple service layer these tests do overlap, but could diverge in the future as the application becomes more complex.*