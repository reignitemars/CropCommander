# CropCommander

CropCommander is a Blazor WebAssembly-based farm management system that helps farmers manage their fields. The system allows users to view, add, and search for fields by name and crop type, providing an intuitive interface and efficient management features.

## Features

- **Field Management**: View and search for fields in a table, with optional filtering by field name or crop.
- **Field Validation**: Add new fields with validation for unique field names and positive area values.
- **Field Name Checking**: Ensure field names are unique through the provided API.
  
## Technologies Used

- **Frontend**: Blazor WebAssembly
- **UI Library**: MudBlazor for modern, responsive UI components
- **Backend**: ASP.NET Core Web API
- **Database**: PostgreSQL ¬@15.10 (local instance)
- **CQRS**: Implements the CQRS (Command Query Responsibility Segregation) design pattern using MediatR to separate read and write operations.

## API Endpoints

### 1. `GET: api/field`
- **Description**: Retrieves a list of fields, with optional filtering by field name or crop name.
- **Query Parameters**:
  - `query` (optional): A search term for filtering by field name or crop name.
- **Response**: Returns a list of fields.

### 2. `POST: api/field`
- **Description**: Adds a new field with a unique name, positive area, and crop name.
- **Request Body**: `Field` object with properties `FieldName`, `FieldArea`, and `CropName`.
- **Response**: Returns the newly created field.

### 3. `GET: api/field/exists`
- **Description**: Checks if a field name already exists in the database.
- **Query Parameters**:
  - `name`: The name of the field to check.
- **Response**: Returns `true` if the field name exists, `false` otherwise.

## Setup and Installation

### Prerequisites

- [.NET 8 or later](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)

### Cloning the Repository

To get started, clone the repository:

```bash
git clone https://github.com/reignitemars/CropCommander.git
cd CropCommander
```

### Database Setup
Set up PostgreSQL and create a new database.
Initialize the database schema with the provided SQL script.

### Configuration
Edit `appsettings.json` to configure your database connection:

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=port;Database=BarnDB;Username=yourusername;Password=yourpassword"
  }
}
```
### Running the Application
Run the application with:

In `CropCommander.API` 
```bash
dotnet run  --launch-profile "https"
```

In `CropCommander.Website` 
```bash
dotnet run  --launch-profile "https"
```
Access the frontend through `https://localhost:7206`.

Important Reminder: Port Configuration

The **CropCommander** project uses the following default ports:

#### API:
- HTTP: `http://localhost:5121`
- HTTPS: `https://localhost:7192`

#### Blazor WebAssembly (Frontend):
- HTTP: `http://localhost:5254`
- HTTPS: `https://localhost:7206`

---

Ensure these ports are free or modify the `launchSettings.json` and `Program.cs` file with avaliable ports.

In `CropCommander.API`

`appsettings.json`:
```bash
"https": {
      ...
      "applicationUrl": "https://localhost:{PosrtForApi};http://localhost:5121",
      ...
    },
```

`Program.cs`

```bash
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWebAssembly", policy =>
    {
        policy.WithOrigins("https://localhost:{PortForWebApp}") // Your Blazor WebAssembly URL
            ...
    });
});
```

In `CropCommander.Website`

`appsettings.json`:
```bash
"https": {
      ...
      "applicationUrl": "https://localhost:{PosrtForApi};http://localhost:5121",
      ...
    },
```

`Program.cs`

```bash
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:{PortForApi}") });
```

## License

[MIT](https://choosealicense.com/licenses/mit/)
