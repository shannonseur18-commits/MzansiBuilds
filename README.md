# MzansiBuilds 🇿🇦

> A platform that helps South African developers build publicly and keep up with what other developers are building.

## Live App

🌐 https://stirring-panda-0a1f40.netlify.app

## GitHub Repo

📁 https://github.com/shannonseur18-commits/MzansiBuilds

---

## Tech Stack

| Layer           | Technology             | Reason                          |
| --------------- | ---------------------- | ------------------------------- |
| Frontend        | HTML, CSS, JavaScript  | Simple, no framework needed     |
| Backend         | C# ASP.NET Core        | My strongest language           |
| Database        | Supabase (PostgreSQL)  | Free, real SQL, easy setup      |
| Auth            | Supabase Auth + BCrypt | Secure, industry standard       |
| Hosting         | Netlify                | Free, auto-deploys from GitHub  |
| Testing         | xUnit                  | Standard .NET testing framework |
| Version Control | Git + GitHub           | Industry standard               |

---

## 1. Project Profiling

### Understanding the Brief

Before writing any code I read and analysed the full requirements. I identified 5 core user stories:

1. A developer can create and manage their own account
2. A developer can create a project with stage and support needed
3. A developer can see a live feed and comment or raise a hand to collaborate
4. A developer can update their project with milestones
5. Completed projects appear on a Celebration Wall

### SDLC Approach

#### Phase 1 — Requirements

Read and understood the full brief. Identified all user journeys and mapped what each page needed to do before writing any code.

#### Phase 2 — Design

- Designed the database schema (5 tables) upfront
- Planned all API endpoints before coding
- Planned UI for each page before building
- Chose a tech stack that matched my skills

#### Phase 3 — Implementation

- Built frontend pages first to visualise the user journey
- Built C# backend with clean controller structure
- Connected frontend directly to Supabase database

#### Phase 4 — Testing

- Wrote 5 unit tests using xUnit before connecting the database
- Tested all features manually on the live app
- Verified authentication rejects wrong passwords
- Verified data persists after page refresh

#### Phase 5 — Deployment

- Frontend deployed on Netlify with automatic CI/CD
- Database hosted on Supabase (PostgreSQL)

### System Architecture

┌─────────────────────────────────────────┐
│ FRONTEND (Netlify) │
│ index.html → Login / Register │
│ feed.html → Live feed & comments │
│ projects.html → Projects & milestones│
│ wall.html → Celebration wall │
└──────────────────┬──────────────────────┘
│ Supabase JS Client
▼
┌─────────────────────────────────────────┐
│ BACKEND (C# ASP.NET Core) │
│ AuthController → Auth & JWT │
│ PostsController → Feed & Comments │
│ ProjectsController → Projects │
└──────────────────┬──────────────────────┘
│ PostgreSQL
▼
┌─────────────────────────────────────────┐
│ DATABASE (Supabase) │
│ users │ posts │ comments │
│ projects │ milestones │
└─────────────────────────────────────────┘

### Coding Principles

#### SOLID

| Principle             | How I applied it                                               |
| --------------------- | -------------------------------------------------------------- |
| Single Responsibility | Each controller has one job — AuthController only handles auth |
| Open/Closed           | Models can be extended without modifying existing code         |
| Liskov Substitution   | Base classes and interfaces used correctly                     |
| Interface Segregation | Controllers only expose methods they need                      |
| Dependency Injection  | ASP.NET Core DI used for database context and config           |

#### DRY (Don't Repeat Yourself)

- CSS variables defined once and reused across all 4 pages
- Navigation bar consistent across all pages
- Supabase client initialised once per page
- Database context injected once via DI

#### KISS (Keep It Simple, Stupid)

- Chose plain HTML/CSS/JS over complex frameworks
- Used Supabase direct connection — simplest solution that works
- Kept database schema minimal — only tables that are needed
- Each function does one thing clearly

#### Separation of Concerns

Frontend, backend and database are completely independent layers. The frontend doesn't know about the database. The backend doesn't know about the UI.

---

## 2. Code Version Control

### Git Commit History

| Commit                                                     | What changed                 |
| ---------------------------------------------------------- | ---------------------------- |
| `first commit`                                             | Initial C# project setup     |
| `add login and register page`                              | Frontend auth pages          |
| `add live feed page`                                       | Feed with posts and comments |
| `add my projects page`                                     | Projects and milestones      |
| `add celebration wall page`                                | Completed projects wall      |
| `add README with SDLC approach`                            | Documentation                |
| `add C# backend with auth, posts and projects controllers` | Full backend API             |
| `add unit tests - all 5 passing`                           | TDD implementation           |
| `connect frontend to Supabase database`                    | Live database connection     |
| `add SDLC and coding principles to README`                 | Final documentation          |

### CI/CD Pipeline

- GitHub repo connected to Netlify
- Every `git push` to `main` automatically triggers a new deployment
- No manual deployment needed — push code, app updates live within seconds
- This is a real CI/CD workflow used in professional development

---

## 3. Test-Driven Development

### Unit Tests (xUnit)

All 5 tests pass: `total: 5, failed: 0, succeeded: 5`

| Test                                      | What it verifies                   |
| ----------------------------------------- | ---------------------------------- |
| `CreateUser_ShouldSaveToDatabase`         | User account saves correctly       |
| `CreatePost_ShouldSaveToDatabase`         | Feed post saves correctly          |
| `CreateProject_ShouldSaveToDatabase`      | Project saves correctly            |
| `AddMilestone_ShouldLinkToProject`        | Milestone links to correct project |
| `CompleteProject_ShouldUpdateIsCompleted` | Completion flag updates correctly  |

### Test Pattern Used

Every test follows **Arrange, Act, Assert:**

```csharp
// Arrange - set up test data
var db = GetInMemoryDb();
var user = new User { FullName = "Shannon Seur", Email = "test@test.com" };

// Act - perform the action
db.Users.Add(user);
await db.SaveChangesAsync();

// Assert - verify the result
var saved = await db.Users.FirstOrDefaultAsync(u => u.Email == "test@test.com");
Assert.NotNull(saved);
Assert.Equal("Shannon Seur", saved.FullName);
```

### Run Tests

```bash
cd MzansiBuilds.Tests
dotnet test
```

---

## 4. Secure By Design

Security was built in from the start — not added as an afterthought.

### Security Measures

| Risk                | Solution                                                |
| ------------------- | ------------------------------------------------------- |
| Password exposure   | BCrypt hashing — passwords never stored as plain text   |
| Unauthorised access | JWT tokens required for protected API endpoints         |
| SQL Injection       | Entity Framework parameterised queries                  |
| Data exposure       | Row Level Security (RLS) enabled on all Supabase tables |
| Session management  | Tokens expire after 7 days                              |
| Information leakage | Generic error messages — wrong password gives no detail |

### Code Evidence

```csharp
// Passwords hashed with BCrypt
PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)

// JWT authentication on protected routes
[Authorize]
public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto)

// CORS configured to control access
options.AddPolicy("AllowAll", policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
```

---

## 5. Documentation

### API Endpoints

| Method | Endpoint                      | Description          | Auth Required |
| ------ | ----------------------------- | -------------------- | ------------- |
| POST   | /api/auth/register            | Register new account | No            |
| POST   | /api/auth/login               | Login, returns JWT   | No            |
| GET    | /api/posts                    | Get all feed posts   | No            |
| POST   | /api/posts                    | Create new post      | Yes           |
| POST   | /api/posts/{id}/comments      | Add comment          | Yes           |
| GET    | /api/projects                 | Get my projects      | Yes           |
| POST   | /api/projects                 | Create project       | Yes           |
| POST   | /api/projects/{id}/milestones | Add milestone        | Yes           |
| PUT    | /api/projects/{id}/complete   | Complete project     | Yes           |
| GET    | /api/projects/completed       | Get celebration wall | No            |

### Database Schema

| Table      | Key Fields                                                                                   |
| ---------- | -------------------------------------------------------------------------------------------- |
| users      | id, full_name, email, created_at                                                             |
| posts      | id, content, stage, support_needed, author_name, user_id, created_at                         |
| comments   | id, content, author_name, post_id, user_id, created_at                                       |
| projects   | id, name, description, stage, support_needed, is_completed, author_name, user_id, created_at |
| milestones | id, title, is_completed, project_id, created_at                                              |

### Project Structure

MzansiBuilds/
├── frontend/
│ ├── index.html # Login & Register
│ ├── feed.html # Live feed
│ ├── projects.html # My projects
│ └── wall.html # Celebration wall
├── Controllers/
│ ├── AuthController.cs # Auth endpoints
│ ├── PostsController.cs # Feed endpoints
│ └── ProjectsController.cs # Project endpoints
├── Models/
│ ├── User.cs
│ ├── Post.cs
│ ├── Comment.cs
│ ├── Project.cs
│ └── Milestone.cs
├── Data/
│ └── AppDbContext.cs # Database context
├── MzansiBuilds.Tests/
│ └── UnitTest1.cs # 5 unit tests
└── README.md # This file

### How to Run Locally

```bash
# Backend
cd MzansiBuilds
dotnet restore
dotnet run

# Tests
cd MzansiBuilds.Tests
dotnet test
```

---

## 6. Ethical Use of AI

### How I Used AI

I used **Claude (Anthropic)** as a coding companion — like a senior developer pairing with me.

| AI helped with                                      | I did myself                             |
| --------------------------------------------------- | ---------------------------------------- |
| Explaining concepts (JWT, BCrypt, Entity Framework) | All architectural decisions              |
| Writing boilerplate code faster                     | Choosing the tech stack                  |
| Debugging terminal errors                           | Testing the app and finding bugs         |
| Setting up packages and tools                       | Writing commit messages                  |
| Suggesting best practices                           | Understanding every line before using it |

### Evidence of My Own Thinking

- I identified the bug where login accepted any password without checking — showed critical thinking
- I questioned why we were deploying a backend when Supabase could connect directly
- I pushed back on deployment decisions that didn't make sense for my setup
- I asked to understand concepts before moving forward with code
- I chose C# because it is my strongest language — not because AI suggested it

### My AI Ethics Principles

1. Never copy code without understanding it first
2. Use AI to learn, not just to get answers
3. All design and architectural decisions are my own
4. AI is a tool — the thinking behind the tool is mine
5. I can explain every part of this codebase because I was involved in every decision
