# Global Logistics Management System (GLMS)
# Overview
-The Global Logistics Management System is an enterprise-level ASP.NET Core MVC web application developed for TechMove Logistics.
It replaces a legacy system based on spreadsheets, emails, and manual processes with a modern, centralised platform.

The system manages:
- Clients
- Contracts
- Service Requests
- File uploads: signed agreements
- Currency conversion: USD -ZAR

---
# Features
*Client Management*
- Create and view clients
- Store contact details and region
- One client can have multiple contracts

*Contract Management*
- Create contracts linked to clients
- Set service levels (Gold, Silver, Bronze)
- Upload signed PDF agreements
- Download stored agreements
- Change contract status (Draft, Active, Expired, OnHold)

*Workflow Validation*
Prevents service requests for:
- Expired contracts
- OnHold contracts
- Enforced at service layer

*Currency Conversion*
Converts USD to ZAR using external API
Stores:
- USD amount
- ZAR amount
- Exchange rate used
- Includes fallback rate if API fails

*File Handling*
- Only PDF uploads allowed
- Max file size: 10MB
- Files saved with unique GUID names
- Stored in /wwwroot/uploads/agreements

*Search and Filtering*
Filter contracts by:
- Date range
- Status
- Implemented using LINQ

---
# Architecture
The application follows a layered architecture:
- Models: Data structure (Client, Contract, ServiceRequest)
- Data Layer: Database context (Entity Framework Core)
- Patterns Layer: Design patterns (Factory, Observer, Repository)
- Services: Business logic
- Controllers: Handle user requests
- Views: UI Razor and Bootstrap

---
# Design Patterns
*Factory Pattern*
- Handles contract creation
- Applies default status logic:
- Gold-Active
- Silver or Bronze-Draft
  
*Observer Pattern*
Reacts to contract status changes
- Audit logging
- Expiry notifications

*Repository Pattern*
Abstracts database access
Improves:
- Testability
- Maintainability
- Separation of concerns

---
# Database
*SQL Server (LocalDB)*
Managed using Entity Framework Core
Tables:
- Clients
- Contracts
- ServiceRequests

*Relationships*
Client to Contracts 1-to-many
Contract to ServiceRequests 1-to-many

---
# Technologies Used
- ASP.NET Core MVC (.NET)
- Entity Framework Core
- SQL Server (LocalDB)
- Bootstrap 5
- xUnit (Unit Testing)

---
# Testing
The project includes 55 unit tests covering:
- Currency calculations
- File validation
- Workflow rules
- Contract date validation
- Factory logic
All tests pass successfully 

---
# Usage
Create clients
Create contracts with PDF upload
Change contract status
Create service requests
View currency conversion
Search and filter contracts

