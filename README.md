# MzansiBuilds 🇿🇦

A platform that helps developers build publicly and keep up with what other developers are building.

## What it does

- Developer can create and manage their own account
- Create projects with stage and support required
- See a live feed of what other developers are building
- Comment and raise a hand for collaboration
- Update project progress with milestones
- Completed projects appear on the Celebration Wall

## Live App

https://stirring-panda-0a1f40.netlify.app

## GitHub Repo

https://github.com/shannonseur18-commits/MzansiBuilds

---

## My SDLC Approach

### 1. Requirements

I read and understood the full brief before writing any code. I identified the key user journeys and what each page needed to do.

### 2. Design

I planned the structure of the app:

- Frontend: HTML, CSS, JavaScript
- Backend: C# ASP.NET Core Web API
- Database: Supabase (PostgreSQL)

Pages planned: Login, Feed, My Projects, Celebration Wall

### 3. Development

I built the frontend first to visualize the user journey, then moved to the backend API and database.

### 4. Testing

Unit tests written using xUnit to test backend logic and API endpoints.

### 5. Deployment

Frontend deployed on Netlify, connected to GitHub for continuous deployment.

---

## Programming Principles Applied

### DRY (Don't Repeat Yourself)

Reused the same navigation bar and styling variables across all pages instead of rewriting them.

### Separation of Concerns

Frontend (HTML/CSS/JS) is completely separate from the Backend (C#). The backend exposes API endpoints and the frontend consumes them.

### SOLID Principles

- **Single Responsibility**: Each C# class has one job
- **Dependency Injection**: Used ASP.NET Core's built-in DI container

### RESTful API Design

Backend follows REST principles with clear endpoints:

- POST /api/auth/register
- POST /api/auth/login
- GET /api/posts
- POST /api/posts
- POST /api/posts/{id}/comments
- GET /api/projects
- POST /api/projects

---

## Tech Stack

| Layer           | Technology            |
| --------------- | --------------------- |
| Frontend        | HTML, CSS, JavaScript |
| Backend         | C# ASP.NET Core       |
| Database        | Supabase (PostgreSQL) |
| Hosting         | Netlify               |
| Version Control | Git & GitHub          |

---

## How to Run Locally

### Frontend

Open any `.html` file in the `frontend` folder in your browser.

### Backend

```bash
cd MzansiBuilds
dotnet restore
dotnet run
```

---

## AI Usage

I used Claude (Anthropic) as a coding companion during development. All architectural decisions, understanding of concepts and problem solving approaches are my own. AI was used to help write and explain code faster, similar to how a developer would use Stack Overflow or documentation.

---

## Unit Tests

Run tests with:

```bash
dotnet test
```
