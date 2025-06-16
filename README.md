# PAWS BACKEND

---

[![standard-readme compliant](https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)

A backend API for the Paws app — a digital pet passport system that allows users to manage their pets' data securely.

## Quickstart

---

Make sure you have [.NET 8 SDK](https://dotnet.microsoft.com/) and a PostgreSQL database up and running.

Create an `appsettings.Development.json` file in the root directory:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=paws;Username=postgres;Password=yourpassword"
  },
  "Jwt": {
    "Key": "your_super_secret_key",
    "Issuer": "PawsAuthServer",
    "Audience": "PawsClient"
  }
}
```

Then run the following commands:

```bash
# Apply migrations
  dotnet ef database update

# Start the server
  dotnet run
```

## Project Structure

---

The project is organized by responsibility:

- `Controllers/`: API endpoints
- `Models/`: Domain entities and DTOs
- `Services/`: Business logic
- `Repositories/`: Database access logic
- `Helpers/`: Utilities and mappers
- `Middleware/`: Custom middlewares

## Swagger

---

Swagger UI is available at:

```
https://localhost:{port}/swagger
```

Use it to test and explore the API during development.

## License

---

MIT © Ilia Dorovskih.
