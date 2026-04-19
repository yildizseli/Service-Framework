# Service-Framework

A layered sample WCF service framework in C# that demonstrates:

- reusable service behaviors (logging, request/response inspection),
- a generic service response contract,
- domain/business/data separation,
- a `UserManagement` module exposed through `ServiceRepository`.

## Project Structure

- `ServiceFramework/`  
  Shared framework primitives for services:
  - service behavior + inspector (`BaseServiceBehavior`, `BaseServiceInspector`)
  - service utilities (`ServiceHelper`)
  - common response models (`ServiceResult<T>`, `ServiceResultStatus`)
  - validation abstractions (`IValidator<T>`, `ValidationResult`)
  - custom `ValidationException`

- `UserManagement/`  
  Business module:
  - domain/data entity (`Data/Entity/User`)
  - repository implementation (`Data/UserRepository`)
  - aggregate/business logic (`Business/User/UserAggregate`)
  - validation (`Business/Validation/UserValidator`)
  - DTO contracts (`Common/DTO/UserDTO`)

- `ServiceRepository/`  
  Service layer:
  - WCF contract (`IUserService`)
  - implementation (`UserManagementService`)
  - uses `[BaseServiceBehavior]` from `ServiceFramework`

- `ServiceRepository.sln`  
  Visual Studio solution containing all projects.

## Architecture

The repository follows a simple layered approach:

1. **Service layer** (`ServiceRepository`) receives requests and returns `ServiceResult<T>`.
2. **Business layer** (`UserManagement.Business`) handles validation and use cases.
3. **Data layer** (`UserManagement.Data`) stores data in an in-memory list via generic repository abstraction.
4. **Framework layer** (`ServiceFramework`) provides cross-cutting concerns (logging, validation contracts, result model).

## Service Contract

`IUserService` exposes these operations:

- `AddUser(string firstName, string lastName, int age)`
- `GetUsers()`
- `GetUser(int id)`
- `DeleteUser(int id)`

All operations return `ServiceResult<T>` with:

- `Result`
- `ResultStatus` (`Unknown`, `Successfull`, `Failed`, `ValidationFailed`)
- `ResultMessage`

## Key Behaviors

- **Global service behavior** via `[BaseServiceBehavior]`
  - inspects request/response lifecycle
  - logs called operation, input payload, output payload, and execution duration
- **Validation flow**
  - `UserValidator` validates basic user fields
  - validation failures throw `ValidationException`
  - service catches and maps to `ValidationFailed`
- **Object mapping**
  - AutoMapper maps `UserManagement.Data.Entity.User` to `UserDTO`

## Prerequisites

- Windows + Visual Studio (WCF-friendly setup)
- .NET Framework **4.5.2**
- NuGet package restore support (projects use classic `packages.config` style)

## Build & Restore

```bash
# restore (if NuGet CLI is installed)
nuget restore ServiceRepository.sln

# build (Developer Command Prompt)
msbuild ServiceRepository.sln /p:Configuration=Debug
