# User Management API

A clean, professional .NET 9 Web API for managing users with CRUD operations, validation, and middleware.

## Features

### ✅ CRUD Operations
- **GET** `/api/users` - Get all users
- **GET** `/api/users/{id}` - Get user by ID
- **POST** `/api/users` - Create new user
- **PUT** `/api/users/{id}` - Update existing user
- **DELETE** `/api/users/{id}` - Delete user

### ✅ Data Validation
- Required field validation
- Email format validation
- Age range validation (18-120)
- Unique email constraint
- Input sanitization

### ✅ Middleware Implementation
- **Request Logging Middleware** - Logs all incoming requests with timing
- **API Key Authentication Middleware** - Protects all API endpoints with API key validation

### ✅ Additional Features
- Professional error handling
- Structured logging
- OpenAPI/Swagger documentation
- In-memory data storage with seeded data

## Getting Started

### Prerequisites
- .NET 9.0 SDK

### Running the Application

1. **Clone/Navigate to the project directory**
2. **Run the application:**
   ```bash
   dotnet run
   ```
3. **Access the API:**
   - Base URL: `https://localhost:7159`
   - Swagger UI: `https://localhost:7159/openapi/v1.json`

### Authentication
All API endpoints require an API key in the header:
```
X-API-Key: user-management-api-key-123
```

### Sample Requests

#### Create User
```http
POST /api/users
Content-Type: application/json
X-API-Key: user-management-api-key-123

{
  "name": "John Doe",
  "email": "john.doe@example.com",
  "age": 30
}
```

#### Update User
```http
PUT /api/users/1
Content-Type: application/json
X-API-Key: user-management-api-key-123

{
  "name": "John Updated",
  "age": 31
}
```

## Project Structure

```
├── Controllers/
│   └── UsersController.cs      # CRUD endpoints
├── Models/
│   └── User.cs                 # User entity
├── DTOs/
│   └── Users/
│       └── UserDto.cs         # Data transfer objects
├── Services/
│   └── UserService.cs         # Business logic
├── Interfaces/
│   └── IUserService.cs        # Service contract
├── Middleware/
│   ├── RequestLoggingMiddleware.cs      # Request logging
│   └── ApiKeyAuthenticationMiddleware.cs # API key authentication
├── Program.cs                  # Application configuration
└── UserManagementAPI.http     # API test requests
```

## Testing

Use the included `UserManagementAPI.http` file to test all endpoints. The file contains:
- All CRUD operations (with API key)
- Validation tests (with API key)
- Authentication tests (testing both valid and invalid API keys)

**Important:** Remember to include the API key header `X-API-Key: user-management-api-key-123` in all requests.

## Assignment Requirements Fulfilled

- [x] **CRUD Endpoints**: Complete GET, POST, PUT, DELETE operations
- [x] **Code Debugging**: Clean, well-structured code ready for debugging
- [x] **Data Validation**: Comprehensive validation with proper error messages
- [x] **Middleware**: Request logging and API key authentication middleware
- [x] **Professional Code**: Clean, organized, and well-documented

## Error Handling

The API provides meaningful error responses:
- `400 Bad Request` - Validation errors
- `401 Unauthorized` - Missing or invalid API key
- `404 Not Found` - User not found
- `409 Conflict` - Duplicate email
- `500 Internal Server Error` - Server errors

## Logging

All requests are logged with:
- Request method and path
- Start and end times
- Response status codes
- Request duration
- Error details when applicable