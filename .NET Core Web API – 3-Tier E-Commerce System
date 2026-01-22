.NET Core Web API – 3-Tier E-Commerce System

This project is a .NET Core Web API built using the 3-Tier Architecture pattern for an E-Commerce platform.
The goal is to ensure clean separation of concerns, scalability, maintainability, and adherence to backend best practices.

** Features

Category & Product Management

Customer Orders

Order Items Handling

Billing & Payment System

Status-based Payment Flow (Pending → Placed → Paid)

Repository Pattern Implementation

Entity Framework Core Support

Clean Architecture & SOLID Principles

 --Architecture Overview

The application follows a 3-Tier Architecture:

1.Presentation Layer (API Layer)

ASP.NET Core Web API

Handles HTTP requests and responses

No business logic

2. Business Logic Layer (BLL / Service Layer)

Contains business rules

Validates data and handles workflows

Uses interfaces for loose coupling

3. Data Access Layer (DAL / Repository Layer)

Handles database operations

Implements Repository Pattern

Uses Entity Framework Core

**Entity Relationships

Category → Product (One-to-Many)

Order → OrderItems (One-to-Many)

Order → Payment (One-to-One)

** Billing Flow

Order is created

Order items are added

Total amount is calculated

Payment record is generated

Payment status updates:

Pending → Placed → Paid

*** Technologies Used

ASP.NET Core Web API

Entity Framework Core

Microsoft SQL Server

Repository Pattern

Dependency Injection

LINQ

C#
