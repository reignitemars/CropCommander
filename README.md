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

### Configuration

The current configuration and setup of **CropCommander** is designed for demonstration purposes only. The following practices should be addressed before deploying to a production environment:

- **Database Connection Strings**: Hardcoded credentials are used for convenience but should be replaced with secure options (e.g., environment variables or secret management tools).
- **Port Configuration**: Default ports are used for local development. These should be dynamically configured or updated to avoid conflicts in production.
- **Database Hosting**: For production environments, use a managed database service (e.g., Azure PostgreSQL, AWS RDS) instead of a local instance.
- **CORS and API Configuration**: Modify CORS settings to be more flexible, allowing for different environments.

For production-ready setups, please refer to best practices for security, performance, and scalability.

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
### Restoring the nuget packages
Before running the application, restore the necessary NuGet packages by running:
```bash
dotnet restore
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

---

### Configuring Azure AD Authentication

Azure Active Directory (Azure AD) can be used to authenticate users for both the frontend (Blazor WebAssembly) and backend API in the **CropCommander** project.

### Key Steps for Integration:

1. **Register the Application in Azure AD**:
   - In the **Azure Portal**, create a new application registration to get the necessary credentials like the **Application ID** and **Tenant ID**.
   - Configure a **Redirect URI** for the Blazor WebAssembly application to enable the redirect after authentication.

2. **API Permissions**:
   - Grant the required API permissions within the Azure AD app registration.

3. **Frontend**:
   - The Blazor project can use **MSAL** to authenticate users against Azure AD.
   - The application will request an ID token from Azure AD, and upon successful login, the user will be granted access to the application.

4. **Backend API**:
   - The API project can validate the ID token sent by the Blazor client using **JWT Bearer Authentication**. This ensures that only authenticated users with valid tokens can access the API.

## License

[MIT](https://choosealicense.com/licenses/mit/)
