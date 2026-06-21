# BlogWebsite

A full-featured blog platform built with ASP.NET Core MVC and Entity Framework Core, featuring role-based access control and a clean responsive UI.

## Features

- Create, read, update, and delete blog posts
- Role-based access — Admin and Author roles with separate permissions
- ASP.NET Core Identity for authentication (register, login, logout)
- Comment system on posts
- Responsive layout with Bootstrap 5

## Tech Stack

- **Framework:** ASP.NET Core MVC (.NET 8)
- **ORM:** Entity Framework Core 8
- **Database:** SQL Server / LocalDB
- **Auth:** ASP.NET Core Identity
- **Frontend:** Razor Views, Bootstrap 5

## Getting Started

### Setup

1. **Clone the repo**
   ```bash
   git clone https://github.com/iasaduzzaman/BlogWebsite.git
   cd BlogWebsite
   ```

2. **Configure the connection string**

   In `BlogWebsite/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlogWebsiteDb;Trusted_Connection=True;"
   }
   ```

3. **Apply migrations**
   ```bash
   cd BlogWebsite
   dotnet ef database update
   ```

4. **Run the app**
   ```bash
   dotnet run
   ```

   Open `https://localhost:7000` in your browser.

## Project Structure

```
BlogWebsite/
├── Controllers/       # MVC controllers
├── Models/            # EF Core entity models
├── Views/             # Razor view templates
├── Data/              # DbContext and migrations
└── wwwroot/           # Static assets (CSS, JS, images)
```

