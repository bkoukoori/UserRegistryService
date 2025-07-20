# UserRegistryService
Microservice API calls to Validate User/UserName and POST call to add UserID along with Account ID.


#  WITS Username Registry Microservice

This is a .NET 6 microservice for managing **unique usernames** tied to **account IDs (GUIDs)** for a game world. It provides RESTful endpoints to validate and store usernames, ensuring data integrity and scalability for 1M+ users.

---

## Technologies Used

- .NET 6 Web API
- Entity Framework Core (InMemory or SQL Server)
- Swagger UI for API testing
- C# 10
- RESTful design

---

##  Features

- Validate usernames (format + uniqueness)
- Associate a unique username with an account ID (Guid)
- Allow username updates by replacing old ones
- Fast InMemory database for testing
- Supports SQL Server for production persistence

---

## Running the Project

### Prerequisites

- Visual Studio 2022 (or newer)
- .NET 6 SDK
- Git

---

### 🛠️ Steps to Run Locally

1. **Clone the repository**  
   ```bash
   git clone https://github.com/bkoukoori/UserRegistryService.git
   cd UserRegistryService
