# Quantity Measurement App

### Progressive Evolution from Fundamental Unit Logic to Secure Enterprise Web API Architecture

**.NET 10 | C# | ASP.NET Core Web API | ADO.NET | SQL Server | JWT | Google OAuth 2.0 | N-Tier Architecture | Swagger**

---

# 1. Executive Summary

The **Quantity Measurement Application** is a progressively evolved software system that began with **basic same-unit equality validation** and matured into a **database-driven, authentication-enabled, enterprise-grade Web API solution**.

The project demonstrates how a simple domain problem can be systematically expanded across multiple use cases (**UC1–UC18**) while preserving backward compatibility, clean architecture boundaries, and production-ready security.

The final system now supports:

* Multi-domain quantity comparison
* Cross-unit conversion
* Arithmetic operations
* Temperature-specific capability restrictions
* Persistent history tracking in SQL Server
* ADO.NET repository implementation
* Secure JWT authentication
* Google OAuth 2.0 login
* Protected user APIs
* Swagger authorization testing

This README follows the **architectural depth and structured flow of your reference file**, but it is fully re-authored in a fresh way for originality and easy explanation.

---

# 2. Project Architecture

The project follows a **strict N-Tier / Layered Architecture**, ensuring separation of concerns and maintainability.

```text
API Layer
   ↓
Business Layer
   ↓
Repository Layer
   ↓
Database Layer (SQL Server)
```

## 2.1 Model Layer

Contains the shared contracts and data structures:

* DTOs
* Entity models
* Enums
* API response wrappers
* Authentication models

## 2.2 Business Layer

Responsible for:

* Core business rules
* Validation orchestration
* Quantity operation workflows
* Authentication workflows
* Security helpers

## 2.3 Repository Layer

Handles:

* SQL connectivity using ADO.NET
* Stored procedure execution
* Insert / update / fetch operations
* History persistence
* User authentication data access

## 2.4 API Layer

Provides:

* REST endpoints
* Controller routing
* Middleware pipeline
* Swagger UI
* JWT authorization configuration
* Dependency injection setup

---

# 3. Use Case Evolution (UC1 → UC18)

The project was developed through a **progressive use-case-driven approach**, where each UC builds on the previous one without breaking existing functionality.

This gradual evolution is one of the biggest strengths of the system because it shows how a simple domain problem can scale into a secure enterprise application.

---

## UC1 – Same Unit Equality

The first use case introduced the core foundation of the project: **checking equality between two quantities of the same unit**.

At this stage, the logic was straightforward:

* compare values directly
* allow same-unit validation
* establish the Quantity object structure

**Example:**

```text
12 ft == 12 ft
```

This UC laid the base for all future quantity operations.

---

## UC2 – Cross Unit Equality

This UC improved equality by supporting **comparison between different units of the same category**.

The main enhancement was:

* convert both values into a common base unit
* compare normalized values
* keep mathematical accuracy

**Example:**

```text
12 inch == 1 foot
```

This introduced the important concept of **base-unit normalization**.

---

## UC3 – Weight Equality

The project was expanded from length to **weight measurement support**.

New units added:

* Kilogram
* Gram
* Pound

The same normalization concept from UC2 was reused here, making the architecture more reusable.

---

## UC4 – Volume Equality

This UC added **volume measurement support**, proving that the quantity design can scale across multiple measurement domains.

New units:

* Litre
* Millilitre
* Gallon

This use case strengthened the idea of **multi-domain measurement handling**.

---

## UC5 – Cross Category Protection

A critical validation use case.

This UC ensured that unrelated categories cannot be compared.

For example:

```text
1 foot != 1 kilogram
```

Added protections:

* runtime category validation
* invalid comparison blocking
* safe error handling for incompatible types

This improved domain correctness.

---

## UC6 – Length Conversion

This UC introduced the first **unit conversion workflow**.

The process:

1. convert source value to base unit
2. convert base unit to target unit
3. return converted result

This made the system useful beyond equality checks.

---

## UC7 – Weight & Volume Conversion

The conversion workflow from UC6 was extended to:

* weight
* volume

This UC generalized the conversion pipeline and made it reusable for multiple categories.

---

## UC8 – Generic Quantity Abstraction

This was a major architectural improvement.

The project moved from category-specific classes to a **generic reusable structure**:

```csharp
Quantity<T>
```

Benefits introduced:

* reduced duplicate code
* reusable logic
* better scalability
* type-safe quantity handling

This UC significantly improved maintainability.

---

## UC9 – Addition

This UC added arithmetic addition between compatible units.

Flow:

* validate category
* convert both values to base unit
* perform addition
* return result in default unit

This was the first arithmetic operation in the project.

---

## UC10 – Addition with Target Unit

A more advanced version of UC9.

This UC allowed users to **choose the output unit for the final result**.

Example:

```text
1 ft + 12 inch = 24 inch
```

This improved flexibility and API usability.

---

## UC11 – Division

This UC introduced division support.

Main features:

* division between compatible units
* scalar result output
* division-by-zero protection
* normalized base-unit calculation

This strengthened arithmetic capability.

---

## UC12 – Subtraction

Added subtraction support using the same conversion-aware arithmetic flow.

The system now supported:

* Add
* Subtract
* Divide

This completed the primary arithmetic module.

---

## UC13 – DRY Arithmetic Refactor

This UC focused on **code quality improvement**.

Problem:

* repeated validation logic
* repeated conversion flow
* duplicate arithmetic steps

Solution:

* helper methods
* reusable arithmetic pipeline
* enum-based operation selection
* centralized validations

This made the codebase cleaner, easier to maintain, and more scalable.

---

## UC14 – Temperature Domain Integration

A new domain was introduced:

* Celsius
* Fahrenheit
* Kelvin

This UC was important because temperature conversion is **non-linear**, unlike length/weight.

Supported:

* equality
* conversion

Restricted:

* addition
* subtraction
* division

This added **capability-based domain rules**.

---

## UC15 – Enterprise API Layer Transformation

This UC transformed the project into an **ASP.NET Core Web API with N-Tier architecture**.

Major additions:

* Controllers
* DTOs
* Middleware
* Dependency Injection
* Swagger
* standardized API responses

This was the architectural shift from:

```text
Domain Project → Enterprise API Application
```

---

## UC16 – SQL Server Integration with ADO.NET

This UC introduced **persistent database support**.

Key work completed:

* SQL Server setup
* ADO.NET connection handling
* repository methods
* stored procedures
* save measurement history
* Docker SQL support

This made the application data-driven.

---

## UC17 – Measurement History APIs

This UC added APIs for complete **measurement history management**.

Features:

* save operation records
* get all history
* fetch by ID
* track success and failure cases
* store error messages
* maintain timestamps

This improved auditing and traceability.

---

## UC18 – Authentication, Security & Google OAuth

This is the final and most advanced UC.

It introduced a complete **user authentication and security module**.

### Features Added

* User registration
* login
* JWT token generation
* secure `/me` endpoint
* password hashing
* Google login
* OAuth 2.0 flow
* Swagger token authorization
* protected APIs

This UC made the application secure and ready for real-world access control.

---

# 4. Core APIs

## Quantity APIs

* Equality
* Convert
* Add
* Subtract
* Divide
* Temperature Convert

## History APIs

* Save Measurement
* Get All Records
* Get Record By ID

## Authentication APIs

* Register
* Login
* Google Login
* Current User (`/me`)

---

# 5. Database Design

## MeasurementRecords

Stores:

* operation type
* input values
* units
* output values
* desired unit
* success flag
* error message
* timestamp

## Users

Stores:

* UserId
* Name
* Email
* PasswordHash
* AuthProvider
* CreatedDate

---

# 6. Technical Concepts Demonstrated

This project showcases:

* OOPs
* Generics
* SOLID principles
* DRY refactoring
* ASP.NET Core Web API
* DTO pattern
* Middleware
* Dependency Injection
* ADO.NET
* Stored Procedures
* SQL Server
* JWT Authentication
* Google OAuth 2.0
* Swagger
* Secure API design
* N-Tier Architecture

---

# 7. Final Conclusion

The **Quantity Measurement Application** evolved from a simple quantity comparison system into a **secure, SQL-integrated, enterprise-grade Web API platform**.

Its biggest strength lies in the **clear progression from UC1 to UC18**, where every use case adds measurable architectural and engineering maturity.

The project now represents a complete journey from **basic quantity comparison logic to a secure, database-backed, enterprise-grade measurement platform**.

Each use case adds a clear layer of technical maturity:

* domain logic
* generic design
* arithmetic scalability
* layered architecture
* database persistence
* secure authentication

The final system is:

* mathematically accurate
* modular
* scalable
* secure
* API-driven
* database integrated
* easy to extend for future use cases
