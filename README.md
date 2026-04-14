# MzansiBuilds 🇿🇦

> A platform that helps South African developers build publicly and keep up with what other developers are building.

## Live App

🌐 https://shannonseur18-commits.github.io/MzansiBuilds/

## GitHub Repo

📁 https://github.com/shannonseur18-commits/MzansiBuilds

---

## Tech Stack

| Layer           | Technology             | Reason                                         |
| --------------- | ---------------------- | ---------------------------------------------- |
| Frontend        | HTML, CSS, JavaScript  | Simple, no framework needed — KISS principle   |
| Backend         | C# ASP.NET Core        | My strongest language, industry standard       |
| Database        | Supabase (PostgreSQL)  | Free, real SQL, easy setup, Row Level Security |
| Auth            | Supabase Auth + BCrypt | Secure, industry standard password hashing     |
| Hosting         | GitHub Pages           | Free, deploys directly from GitHub repo        |
| Testing         | xUnit                  | Standard .NET testing framework                |
| Version Control | Git + GitHub           | Industry standard, full commit history         |

---

## 1. Project Profiling

### Understanding the Brief

Before writing a single line of code I read and analysed the full requirements. I broke the brief down into 5 core user stories:

1. A developer can create and manage their own account
2. A developer can create a project with stage and support needed
3. A developer can see a live feed and comment or raise a hand to collaborate
4. A developer can update their project progress with milestones
5. Completed projects appear on a Celebration Wall amongst other developers

This upfront analysis prevented me from building the wrong thing and gave me a clear picture of what pages, database tables and API endpoints I needed before I started coding.

---

### SDLC Approach

I followed the full Software Development Life Cycle on this project:

#### Phase 1 — Requirements Analysis

- Read and understood the full MzansiBuilds brief
- Identified all 5 user journeys
- Mapped out what each page needed to do
- Identified the tech stack that matched my skills

#### Phase 2 — System Design

- Designed the database schema upfront — 5 tables: users, posts, comments, projects, milestones
- Planned all API endpoints before writing any code
- Created the system architecture showing all 3 layers
- Planned the UI layout for each page before building

#### Phase 3 — Implementation

- Built frontend pages first to visualise the user journey
- Built C# ASP.NET Core backend with 3 controllers
- Connected frontend directly to Supabase database
- Added input validation and error handling throughout

#### Phase 4 — Testing

- Wrote 5 unit tests using xUnit following TDD principles
- Tested all features manually on the live app
- Verified authentication rejects wrong passwords and empty fields
- Verified data persists after page refresh
- Verified delete functionality removes data from database

#### Phase 5 — Deployment

- Frontend deployed on GitHub Pages — auto deploys on git push
- Database hosted on Supabase (PostgreSQL)
- CI/CD pipeline: every git push triggers automatic redeployment

---

### System Architecture

┌─────────────────────────────────────────┐
│ FRONTEND (GitHub Pages) │
│ index.html → Login / Register │
│ feed.html → Live feed & comments │
│ projects.html → Projects & milestones│
│ wall.html → Celebration wall │
│ reset-password → Password reset │
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

---

### Coding Principles

#### SOLID

SOLID is a set of 5 principles for writing clean, maintainable object-oriented code. Here is how I applied each one:

| Principle                     | What it means                                              | How I applied it                                                                                                                                   |
| ----------------------------- | ---------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- |
| **S** — Single Responsibility | Every class should have one job                            | AuthController only handles auth. PostsController only handles posts. ProjectsController only handles projects. No class does more than one thing. |
| **O** — Open/Closed           | Open for extension, closed for modification                | My models (User, Post, Project) can have new properties added without changing existing code                                                       |
| **L** — Liskov Substitution   | Subclasses should be replaceable for base classes          | Interfaces and base classes used correctly throughout the C# backend                                                                               |
| **I** — Interface Segregation | Don't force classes to implement what they don't need      | Each controller only exposes the endpoints relevant to its responsibility                                                                          |
| **D** — Dependency Injection  | Classes should receive their dependencies, not create them | ASP.NET Core DI container injects AppDbContext and IConfiguration into controllers — they don't create these themselves                            |

#### DRY — Don't Repeat Yourself

DRY means every piece of knowledge should exist in one place. If you find yourself writing the same code twice, extract it.

How I applied DRY in MzansiBuilds:

- **CSS variables** defined once in `:root` and reused across all pages — changing `--green-main` updates the colour everywhere
- **Navigation bar** has the same structure across all 4 pages — consistent without copy-pasting logic
- **Supabase client** initialised once per page and reused for all database calls
- **`getInitials()` function** written once and called wherever initials are needed
- **`timeAgo()` function** written once and reused for all timestamps
- **AppDbContext** injected once via DI and shared across all C# controllers

#### KISS — Keep It Simple, Stupid

KISS means choosing the simplest solution that works. Complexity is the enemy of reliability.

How I applied KISS in MzansiBuilds:

- Chose plain **HTML, CSS and JavaScript** over React or Angular — the requirements didn't need a complex framework
- Used **Supabase direct connection** from the frontend instead of routing everything through a deployed backend — simpler architecture, same result
- Kept the **database schema minimal** — only 5 tables, only the columns actually needed
- Each JavaScript function **does one thing** — `loadPosts()` only loads posts, `addPost()` only adds a post, `toggleComments()` only toggles comments
- Used **localStorage** for simple session management instead of complex token handling on the frontend

#### Separation of Concerns

The frontend, backend and database are completely independent layers:

- The **frontend** only handles what the user sees and interacts with
- The **backend** only handles business logic and data validation
- The **database** only stores and retrieves data
- None of these layers know about the internal workings of the others

---

## 2. Code Version Control

### Git Workflow

I used Git throughout the entire development process with a clear and consistent workflow:

1. Write the feature code
2. Test it works locally
3. Stage changes with `git add .`
4. Commit with a descriptive message using `git commit -m "message"`
5. Push to GitHub with `git push`
6. GitHub Pages automatically redeploys the live app

### Commit History

| Commit                                                                   | What changed                 |
| ------------------------------------------------------------------------ | ---------------------------- |
| `first commit`                                                           | Initial C# project setup     |
| `add login and register page`                                            | Frontend auth pages          |
| `add live feed page`                                                     | Feed with posts and comments |
| `add my projects page`                                                   | Projects and milestones      |
| `add celebration wall page`                                              | Completed projects wall      |
| `add README with SDLC approach`                                          | Documentation                |
| `add C# backend with auth, posts and projects controllers`               | Full backend API             |
| `add unit tests - all 5 passing`                                         | TDD implementation           |
| `connect frontend to Supabase database`                                  | Live database connection     |
| `add feed banner, project description, delete project and code comments` | CRUD and UX improvements     |
| `add confetti celebration wall`                                          | Celebration wall animation   |
| `fix validation clearing on input and forgot password redirect`          | Auth improvements            |
| `add reset password page with confirm password validation`               | Password reset flow          |
| `rename frontend to docs for GitHub Pages`                               | Hosting migration            |

### CI/CD Pipeline

- GitHub repo connected to GitHub Pages
- Every `git push` to `main` automatically triggers a new deployment
- No manual deployment needed — push code, live app updates within minutes
- This mirrors the CI/CD workflow used in professional software teams

---

## 3. Test-Driven Development

### Approach

I followed the Red-Green-Refactor TDD cycle:

1. **RED** — Write a failing test first
2. **GREEN** — Write the minimum code to make it pass
3. **REFACTOR** — Clean up the code without breaking the test

Writing tests first forced me to think clearly about what each function was supposed to do before writing it. This produced cleaner, more focused code.

### Unit Tests (xUnit)

All 5 tests pass: `total: 5, failed: 0, succeeded: 5`

| Test                                      | What it verifies                         |
| ----------------------------------------- | ---------------------------------------- |
| `CreateUser_ShouldSaveToDatabase`         | User account saves correctly to database |
| `CreatePost_ShouldSaveToDatabase`         | Feed post saves with correct content     |
| `CreateProject_ShouldSaveToDatabase`      | Project saves with all fields            |
| `AddMilestone_ShouldLinkToProject`        | Milestone correctly links to its project |
| `CompleteProject_ShouldUpdateIsCompleted` | Completion flag updates to true          |

### Test Pattern — Arrange, Act, Assert

```csharp
[Fact]
public async Task CreateUser_ShouldSaveToDatabase()
{
    // Arrange — set up test data
    var db = GetInMemoryDb();
    var user = new User
    {
        FullName = "Shannon Seur",
        Email = "shannon@test.com",
        PasswordHash = "hashedpassword123"
    };

    // Act — perform the action being tested
    db.Users.Add(user);
    await db.SaveChangesAsync();

    // Assert — verify the expected outcome
    var saved = await db.Users
        .FirstOrDefaultAsync(u => u.Email == "shannon@test.com");
    Assert.NotNull(saved);
    Assert.Equal("Shannon Seur", saved.FullName);
}
```

### Run Tests

```bash
cd MzansiBuilds.Tests
dotnet test
```

---

## 4. Secure By Design

Security was designed in from the start — not added as an afterthought.

### Security Measures

| Risk                    | Solution                      | Implementation                                                      |
| ----------------------- | ----------------------------- | ------------------------------------------------------------------- |
| Password exposure       | BCrypt hashing                | Passwords hashed before storing — never plain text                  |
| Unauthorised API access | JWT tokens                    | `[Authorize]` attribute on all protected endpoints                  |
| SQL Injection           | Parameterised queries         | Entity Framework Core handles this automatically                    |
| Database exposure       | Row Level Security            | RLS enabled on all 5 Supabase tables                                |
| Session hijacking       | Token expiry                  | JWT tokens expire after 7 days                                      |
| Information leakage     | Generic errors                | Wrong password returns "Incorrect email or password" — no specifics |
| Invalid input           | Frontend + backend validation | Both layers validate before processing                              |

### Security Code Evidence

```csharp
// Passwords hashed with BCrypt — one way, cannot be reversed
PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)

// BCrypt verify on login — never decrypts, only compares
BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash)

// JWT token required on all write endpoints
[Authorize]
public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto)

// CORS configured to control which domains can access the API
options.AddPolicy("AllowAll", policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
```

### Frontend Security

- Name validation — only letters and spaces allowed (no scripts or numbers)
- Email format validated before any API call
- Password minimum 6 characters enforced
- Error messages cleared when user starts correcting input
- Sign out clears all local session data

---

## 5. Documentation

### Code Documentation

All code is documented with inline comments explaining the purpose of each function. Example:

```javascript
// Get initials from a full name e.g. "Shannon Seur" → "SS"
function getInitials(name) {
  return name
    .split(" ")
    .map((w) => w[0])
    .join("")
    .toUpperCase()
    .slice(0, 2);
}

// Convert timestamp to human readable time e.g. "2h ago"
function timeAgo(date) {
  const seconds = Math.floor((new Date() - new Date(date)) / 1000);
  if (seconds < 60) return "just now";
  if (seconds < 3600) return Math.floor(seconds / 60) + "m ago";
  if (seconds < 86400) return Math.floor(seconds / 3600) + "h ago";
  return Math.floor(seconds / 86400) + "d ago";
}
```

### API Endpoints

| Method | Endpoint                      | Description           | Auth |
| ------ | ----------------------------- | --------------------- | ---- |
| POST   | /api/auth/register            | Register new account  | No   |
| POST   | /api/auth/login               | Login, returns JWT    | No   |
| GET    | /api/posts                    | Get all feed posts    | No   |
| POST   | /api/posts                    | Create new post       | Yes  |
| POST   | /api/posts/{id}/comments      | Add comment to post   | Yes  |
| GET    | /api/projects                 | Get my projects       | Yes  |
| POST   | /api/projects                 | Create new project    | Yes  |
| POST   | /api/projects/{id}/milestones | Add milestone         | Yes  |
| PUT    | /api/projects/{id}/complete   | Mark project complete | Yes  |
| GET    | /api/projects/completed       | Get celebration wall  | No   |

### Database Schema

| Table      | Fields                                                                                       |
| ---------- | -------------------------------------------------------------------------------------------- |
| users      | id, full_name, email, created_at                                                             |
| posts      | id, content, stage, support_needed, author_name, user_id, created_at                         |
| comments   | id, content, author_name, post_id, user_id, created_at                                       |
| projects   | id, name, description, stage, support_needed, is_completed, author_name, user_id, created_at |
| milestones | id, title, is_completed, project_id, created_at                                              |

### Project Structure

MzansiBuilds/
├── docs/ # Frontend (served by GitHub Pages)
│ ├── index.html # Login & Register
│ ├── feed.html # Live feed with posts & comments
│ ├── projects.html # My projects & milestones
│ ├── wall.html # Celebration wall
│ └── reset-password.html # Password reset
├── Controllers/
│ ├── AuthController.cs # Register, login, JWT
│ ├── PostsController.cs # Posts, comments
│ └── ProjectsController.cs # Projects, milestones
├── Models/
│ ├── User.cs
│ ├── Post.cs
│ ├── Comment.cs
│ ├── Project.cs
│ └── Milestone.cs
├── Data/
│ └── AppDbContext.cs # EF Core database context
├── MzansiBuilds.Tests/
│ └── UnitTest1.cs # 5 xUnit tests
└── README.md

### How to Run Locally

```bash
# Run backend
cd MzansiBuilds
dotnet restore
dotnet run

# Run tests
cd MzansiBuilds.Tests
dotnet test

# Run frontend
# Open any .html file in the docs folder in your browser
```

---

## 6. Ethical Use of AI

### How I Used AI

I used **Claude (Anthropic)** as a coding companion throughout this project — like a senior developer pairing with me.

| AI helped with                                                    | I did myself                                                    |
| ----------------------------------------------------------------- | --------------------------------------------------------------- |
| Explaining concepts I didn't know (JWT, BCrypt, Entity Framework) | All architectural decisions                                     |
| Writing boilerplate code faster                                   | Choosing the tech stack (C# because it's my strongest language) |
| Debugging terminal errors                                         | Testing the app and finding bugs myself                         |
| Setting up packages and tools                                     | Writing all commit messages                                     |
| Suggesting best practices                                         | Understanding every line before using it                        |

### Evidence of My Own Thinking

- I identified the bug where login accepted any password without checking — this showed critical thinking and testing
- I questioned why we needed to deploy a backend when Supabase could connect directly from the frontend — I pushed back on complexity
- I rejected deployment approaches that kept failing and found simpler solutions
- I noticed the feed was empty for new users and suggested adding seed data
- I suggested adding delete functionality because I understood CRUD was incomplete
- I asked what "intuitive" meant before making UI decisions — I wanted to understand, not just follow instructions
- I chose C# because it is my strongest language — not because AI suggested it

### My AI Ethics Principles

1. Never copy code without understanding what it does first
2. Use AI to learn concepts, not just to get answers
3. All design and architectural decisions are my own
4. AI is a tool — the thinking, questioning and decision-making behind it is mine
5. I can explain every part of this codebase because I was involved in every single decision
6. Being transparent about AI use is a sign of professionalism — hiding it would be dishonest
