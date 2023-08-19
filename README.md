# CarQuest ASP.NET Core Application

Welcome to CarQuest, an ASP.NET Core application that helps users manage their cars, mechanics, and tickets related to car issues.

## Features

- **User Registration and Login:** Users can register and log in to the application to access personalized features.

- **Manage Cars:** Users can add, view, update, and delete cars in their collection. Car details including brand, model, year, mileage, and image can be managed.

- **Become a Mechanic:** Skilled mechanics can become registered users on the platform by providing their phone number and shop address.

- **Manage Tickets:** Users can create tickets for car issues, selecting the affected car and providing a title and description. Assigned mechanics can be tracked.
  
- **Take Tickets** Mechanics can take the tickets.

- **Manage Offers** Mechanics can create offers for tickets and users can accept or decline them

- **Admin Area:** The application includes an admin area for managing system-wide settings and data.

## Getting Started

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/yourusername/CarQuest.git
   cd CarQuest

2. **Setup the Database:**
   - Configure the database connection string in appsettings.json.
   - Open the Package Manager Console in Visual Studio (View > Other Windows > Package Manager Console).
   - Run migrations to create the required database schema:
     ```sh
     Add-Migration [Your Migration Name]
     Update-Database

3. **Run the Application:**
  - Press F5 in Visual Studio to build and run the application.

**Admin Access:**
  - An admin is seeded with the database. Simply login with the credentials below:
  - Email: admin@carquest.com
  - Password: 123456

**Additional Seeded Users**
  -A Mechanic with email: testmechanicuser@carquest.com
  -A User with email: testuser@carquest.com
  -Both have the password: 123456

**The project is published in Azure**
  -Here is the link to the site: https://carquestweb20230819003419.azurewebsites.net/
    
**Technologies Used**
  - ASP.NET Core
  - Entity Framework Core
  - Razor Pages
  - Bootstrap (for styling)
  - SQL Server
  - Auto Mapper
  - NUnit
  - Fluent Assertion
  - Azure
