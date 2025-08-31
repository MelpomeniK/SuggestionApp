# SuggestionApp

**SuggestionApp** is an ASP.NET Core MVC web application designed to manage Departments, Roles, and Suggestions efficiently.
It features a Dashboard that provides an overview of key metrics, including the number of departments, managers, and the count of accepted and rejected suggestions.
The application is ideal for organizations looking to streamline suggestion tracking and role management in a centralized system.

## Requirements
Before you begin, ensure you have the following installed:
- .NET 8 SDK or later
- SQL Server
- Visual Studio 2022 with ASP.NET workload
- Entity Framework Core Tools
  
# Setup & Deployment Guide

## Installation
1. If the required dependencies are not already installed, install them.  
2. In the `appsettings.json` file, update the `DefaultConnection` with your database connection string.  
3. Open the **Package Manager Console** and run:
   ```powershell
   Add-Migration InitialCreate
   Update-Database
   
## Publish
1. Right-click on the project and select Publish.
2. Choose Folder as the publish target and click Next.
3. Select the folder where you want the publish output to be generated and click Close.
4. Select Show all settings, set Deployment Mode to Self-contained, and click Save.

## Deployment
1. Click Publish.
2. Navigate to the publish folder.
3. Double-click the generated .exe file to run the application.
