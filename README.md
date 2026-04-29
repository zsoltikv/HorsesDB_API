## 1️⃣ Create Project

- Project type: **ASP.NET Core Web API**  
- Framework: **.NET 10.0**  
- Settings:
  - Use Controllers  
  - Enable HTTPS  
  - Enable Open API (Swagger)  

---

## 2️⃣ Create Database (SQL Server)

1. Open **SQL Server Object Explorer → New Query**.  
2. Run the following SQL command:

```sql
-- CREATE DATABASE horsesDB
-- USE horsesDB

-- Create the Horses table (with all the necessary columns)
CREATE TABLE Horses (
    HorseID INT IDENTITY PRIMARY KEY,
    HorseName VARCHAR(100),
    BreedName VARCHAR(100),
    BreedOrigin VARCHAR(100),
    OwnerFirstName VARCHAR(100),
    OwnerLastName VARCHAR(100),
    OwnerContact VARCHAR(100),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    Color VARCHAR(50),
    RaceName VARCHAR(100),
    RaceDate DATE,
    RaceLocation VARCHAR(100),
    RaceDistance INT,
    FinishPosition INT
);

-- Insert data into the Horses table
INSERT INTO Horses (HorseName, BreedName, BreedOrigin, OwnerFirstName, OwnerLastName, OwnerContact, DateOfBirth, Gender, Color, RaceName, RaceDate, RaceLocation, RaceDistance, FinishPosition)
VALUES
('Stormy', 'Thoroughbred', 'United Kingdom', 'John', 'Doe', 'john.doe@email.com', '2015-06-12', 'Male', 'Bay', 'Grand Derby', '2025-05-15', 'New York', 2400, 2),
('Whisper', 'Arabian', 'Saudi Arabia', 'Alice', 'Smith', 'alice.smith@email.com', '2018-04-22', 'Female', 'Gray', 'Grand Derby', '2025-05-15', 'New York', 2400, 1),
('Blaze', 'Mustang', 'United States', 'Robert', 'Brown', 'robert.brown@email.com', '2017-08-01', 'Male', 'Chestnut', 'Spring Invitational', '2025-06-10', 'Los Angeles', 1800, 3),
('Thunder', 'Clydesdale', 'Scotland', 'Emily', 'Davis', 'emily.davis@email.com', '2016-10-15', 'Male', 'Black', 'Champions Cup', '2025-07-04', 'Chicago', 2200, 4),
('Princess', 'Andalusian', 'Spain', 'Michael', 'Johnson', 'michael.johnson@email.com', '2019-03-10', 'Female', 'White', 'Summer Sprint', '2025-08-01', 'Miami', 1600, 1),
('Stormy', 'Thoroughbred', 'United Kingdom', 'John', 'Doe', 'john.doe@email.com', '2015-06-12', 'Male', 'Bay', 'Autumn Classic', '2025-09-20', 'Dallas', 2000, 5),
('Whisper', 'Arabian', 'Saudi Arabia', 'Alice', 'Smith', 'alice.smith@email.com', '2018-04-22', 'Female', 'Gray', 'Autumn Classic', '2025-09-20', 'Dallas', 2000, 3);
```

## 3️⃣ Install NuGet Packages (Package Manager Console)
- Install-Package Microsoft.EntityFrameworkCore.SqlServer 
- Install-Package Microsoft.EntityFrameworkCore.Design 
- Install-Package Microsoft.EntityFrameworkCore.Tools
- Install-Package Swashbuckle.AspNetCore.SwaggerUI

## 4️⃣ Scaffold Database (from existing DB - Package Manager Console)
```
Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=horsesDB;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context HorsesDBContext -DataAnnotations
```
-OutputDir Models → folder for generated models<br>
-Context NascarDBContext → name of the DbContext<br>
-DataAnnotations → use annotations in models

## 5️⃣ Configure Connection String (appsettings.json)
```
{
  "ConnectionStrings": {
    "DefaultConnectionString": "SERVER=(localdb)\\MSSQLLocalDB;DATABASE=horsesDB;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## 6️⃣ Register DbContext in Program.cs
## 📍 Where to add `AddDbContext` in `Program.cs`

Open **Program.cs** and add the following code **INSIDE the service configuration section**,  
**after** `var builder = WebApplication.CreateBuilder(args);`  
and **before** `builder.Services.AddControllers();`

---

### ✅ Correct placement

```csharp
var builder = WebApplication.CreateBuilder(args);

// 👇 ADD THIS HERE
builder.Services.AddDbContext<HorsesDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// 👇 Already existing code
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```

## 7️⃣ Create Controller (Scaffolded API Controller – EntityFramework)

---

### 📁 Steps in Visual Studio

1. Open **Solution Explorer**
2. Right-click on the **Controllers** folder
3. Select:
   **Add** → **New Scaffolded Item…**
4. Choose:
   **API Controller with actions, using Entity Framework**
5. Click **Add**

---

### ⚙️ Scaffold Configuration

Fill in the fields as follows:

| Field | Value |
|---------------------|-----------------------|
| **Model class**     | `Horse`           |
| **DbContext class** | `HorsesDBContext`     |
| **Controller name** | `HorsesController` |

Then click **Add**.

---
