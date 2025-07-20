# WITS Username Microservice

## Setup
1. Open with Visual Studio 2022.
2. Run the project. Swagger UI will open.
3. Use GET `/api/user/validate` and POST `/api/user`.


Purpose: Validates whether a username meets the format requirements and checks if it's already taken.



GET /api/user/validate?username={username}
Query Parameters:

username (string, required): The username to validate.
Rules:

Must be 6–30 characters long.
Alphanumeric only (A–Z, a–z, 0–9).
Must be unique (not already stored).
Responses:

200 OK – Username is valid and available.
400 Bad Request – Username does not meet format requirements.
409 Conflict – Username is already taken.


POST /api/user
Purpose: Registers or updates a username for a specific account ID.

Request Body:
{
  "accountId": "a-valid-guid",
  "username": "NewPlayer01"
}
Behavior:

If the username is invalid → reject with error.
If the username is taken → reject with conflict.
If the account ID exists → replaces the old username.
Otherwise, creates a new entry.
Responses:

200 OK – Username registered or updated successfully.
400 Bad Request – Invalid format or input.
409 Conflict – Username already exists.


## Tech Stack
- .NET 6
- EF Core
- InMemory DB (for demo, switchable to SQL Server)

## Notes
- Unique constraint on usernames.
- One account ID = one username.
- Username must be 6-30 characters, alphanumeric only.

## Build & Run
```bash
dotnet build
dotnet run


# example created using POST
{
  "accountId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "username": "20RGMAYAC2zyBjEoLJkwyX"
}