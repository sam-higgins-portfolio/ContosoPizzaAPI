# Technologies
- C#
- ASP.NET

# Description
A simple ASP.NET API to act as the backend for the [ContosoPizzaWeb](https://github.com/sam-higgins-portfolio/ContosoPizzaWeb) project.

# Running

Runs on http://localhost:5020

```
dotnet run
```
# Development

1. Created shell project using:
```csharp
dotnet new ContosoPizzaAPI -controllers -f net9.0
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
