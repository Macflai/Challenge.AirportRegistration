# Travelport Airport Registration API

API for managing airports and registered people.  

**Main project:** `Travelport.AirportRegistration.WebApi`

---

## Technologies / Implemented Features

- .NET 8 Web API  
- Entity Framework Core (InMemory for unit tests)  
- xUnit + Moq + FluentAssertions for testing  
- Repository Pattern + Service Layer  
- Clean code principles applied  
- Endpoints available via Swagger  
- Validations with DataAnnotations  
- Logging using ILogger  

---

## Project Structure

- `Travelport.AirportRegistration.WebApi` → Main API  
- `Travelport.AirportRegistration.Infrastructure` → Persistence and repositories  
- `Travelport.AirportRegistration.Domain` → Domain entities  
- `Travelport.AirportRegistration.UnitTests` → Unit tests  

---

## Main Endpoints

### Airports

- `GET /api/airports` → All airports  
- `GET /api/airports/{id}` → Airport by ID  
- `GET /api/airports/code/{code}` → Airport by code  
- `POST /api/airports` → Create an airport  
- `PUT /api/airports/{id}` → Update an airport  
- `DELETE /api/airports/{id}` → Delete an airport  

### People

- `GET /api/people` → All people  
- `GET /api/people/{id}` → Person by ID  
- `GET /api/people/passport/{passportNumber}` → Person by passport number  
- `POST /api/people` → Create a person  
- `PUT /api/people/{id}` → Update a person  
- `DELETE /api/people/{id}` → Delete a person  

**Note:** Endpoints should ideally be secured, although it was not required in the original assignment.

---

## Testing

Unit tests cover:

- **Services** → Verify correct calls to repositories and returned data.  
- **Repositories** → Using EF Core InMemory for CRUD operations validation without a real database.  

**Note:** Integration tests (as a new separate project within the tests folder) are considered a future enhancement.

---

## Possible Improvements

- FluentValidation for more flexible validations  
- PATCH for partial updates to Person  
- Serilog for structured logging  
- Centralized error-handling middleware  
- CQRS pattern for separating commands and queries  
- Integration tests at the controller level using a real database  
- Additional validations: uniqueness of airport codes, passport numbers, emails

---

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/Macflai/Challenge.AirportRegistration.git
cd Travelport.AirportRegistration.WebApi
```

2. Restore NuGet packages:
```bash
dotnet restore
```

3. Build the solution:
```bash
dotnet build
```

4. Run the Web API:
```bash
dotnet run --project Travelport.AirportRegistration.WebApi
```

5. Open Swagger to explore available endpoints:
Navigate to https://localhost:<port>/swagger in your browser.

6. Run unit tests:
```bash
dotnet test Travelport.AirportRegistration.UnitTests
```

7. (Optional) Clean and rebuild the solution if needed:
```bash
dotnet clean
dotnet build
```
