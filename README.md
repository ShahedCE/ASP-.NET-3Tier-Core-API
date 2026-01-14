# .NET Core Web API – 3 Tier Architecture

This project is a **.NET Core Web API** built using the **3-Tier Architecture** pattern.  
The goal of this project is to maintain **clean separation of concerns**, improve **scalability**, **maintainability**, and follow **best practices** for backend development.

---

##  Architecture Overview

The application follows a **3-Tier Architecture**:

1. **Presentation Layer (API Layer)**
   - ASP.NET Core Web API
   - Handles HTTP requests and responses
   - Does not contain business logic

2. **Business Logic Layer (BLL / Service Layer)**
   - Contains application business rules
   - Acts as a bridge between API and Data Access Layer
   - Uses interfaces for loose coupling

3. **Data Access Layer (DAL / Repository Layer)**
   - Handles database operations
   - Uses Repository Pattern
   - Can be implemented using **Entity Framework Core / Dapper / ADO.NET**


