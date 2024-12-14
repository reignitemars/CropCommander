# **CropCommander**

## **Overview**
**CropCommander** is a Blazor WebAssembly-based farm management system designed to help farmers manage their fields. It allows users to view, add, and search for fields by name and crop.

## **Features**
- View and search fields in a table with optional filtering.
- Add new fields with validation for unique field names and positive area values.
- Check if a field name already exists.

## **Technologies Used**
- **Frontend**: Blazor WebAssembly
- **UI Library**: MudBlazor
- **Backend**: ASP.NET Core (API)
- **Database**: PostgreSQL (local instance)
- **CQRS Design**: Commands and Queries are handled via **MediatR**

## **API Endpoints**

### 1. **GET: `api/field`**
   - **Description**: Retrieves a list of fields, with optional filtering by field name or crop name.
   - **Query Parameters**: 
     - **`query`** (optional): Search for fields by name or crop.
   - **Response**: Returns a list of fields.

### 2. **POST: `api/field`**
   - **Description**: Adds a new field with a unique name, positive area, and crop name.
   - **Request Body**: `Field` object (**FieldName**, **FieldArea**, **CropName**).
   - **Response**: Returns the newly created field.

### 3. **GET: `api/field/exists`**
   - **Description**: Checks if a field name already exists.
   - **Query Parameters**: 
     - **`name`**: The name of the field to check.
   - **Response**: Returns `true` if the field name exists, `false` otherwise.
