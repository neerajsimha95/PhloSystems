
```markdown
# .NET API Project for Phlo Systems Interview

## Overview
This project is a .NET 8 API that demonstrates API key validation and consumes the given products endpoint. It uses ASP.NET Core and Swashbuckle for API documentation.

## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or Visual Studio Code

## Setup

1. **Clone the repository**:
   ```bash
   git clone https://github.com/neerajsimha95/PhloSystems.git
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Update configuration**:
   Add your API key and products URL in the `appsettings.json` file:
   ```json
   {
       "x-api-key": "your-secure-api-key"
   }
    {
        "ThirdPartyAPIs": { 
        "ProductsEndpoint": "Your_API_Products_URL"
      }
    }
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

## API Documentation
The API documentation is available via Swagger. Once the application is running, navigate to `https://localhost:7029/swagger` to view and interact with the API endpoints.

## API Key Validation
This project uses an API key for securing endpoints. The API key must be included in the request headers as `x-api-key`.

### Example Request
```http
GET /api/securedata HTTP/1.1
Host: localhost:7029
x-api-key: your-secure-api-key
```

## Project Structure
- **Controllers**: Contains the API controllers.
- **PhloSystems.Domain**: Contains the data models and DTOs.
- **PhloSystems.Service**: Contains the business logic related to requesting the Products api.
- **Program.cs**: The main entry point of the application.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
No License Required

## Contact
For any questions or feedback, please contact neerajsinha95@hotmail.com.
```

If you need any more details or have other questions, let me know!