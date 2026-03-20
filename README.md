# RSI Web App — Academic Year 2024 (T24)

Course materials and worked examples for **Razvoj softvera I** (Software Development I): full-stack patterns using an **Angular** client and an **ASP.NET Core** Web API, aligned with the FIT-style exam template from January 2024.

This repository is meant for **tutoring and practice**—students can compare solutions, trace requests from UI to database, and reuse the template as a starting point for assignments.

---

## What’s in the repo

| Path | Purpose |
|------|--------|
| **`Template 2024/`** | Baseline solution: `angular_app` + `webapi` (`rs1-webapi-ispit.sln`). Use this as the canonical starting structure. |
| **`Workshops/`** | Session snapshots for exam-style work (**Ispitni 1–3**), dated Feb, Sep, and Nov 2024. Each folder is a self-contained copy of the stack so you can open and run it without affecting other sessions. |
| **`rs1-2024-01-23-ispitni-zadaci.rar`** | Archived copy of the original template bundle (optional). |
| **`Student Sheet.xlsx`** | Supplementary student reference (if applicable to your group). |

---

## Tech stack

- **Front end:** Angular **13**, TypeScript, RxJS; optional **SignalR** and **Chart.js** where included in `package.json`.
- **Back end:** **ASP.NET Core** Web API targeting **.NET 6**, **Entity Framework Core** with **SQL Server**, **Swagger** (Swashbuckle), Identity-related packages as used in the template.

Exact versions are defined per project in `package.json` (Angular) and `FIT_Api_Examples.csproj` (API).

---

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) (LTS compatible with Angular 13; npm comes with Node)
- [SQL Server](https://www.microsoft.com/sql-server) (or compatible instance) and permission to create/use a database
- Optional: [Angular CLI 13](https://angular.io/cli) globally (`npm i -g @angular/cli@13`) or use `npx ng` via local `node_modules`

---

## Running a project (any folder that contains `angular_app` + `webapi`)

1. **Database**  
   Open `webapi/FIT_Api_Examples/appsettings.json` (and `appsettings.Development.json` if present) and set **`ConnectionStrings:DefaultConnection`** to your server, database name, and credentials. Apply migrations if the course workflow expects it (typically from the `webapi` project directory):

   ```bash
   dotnet ef database update --project FIT_Api_Examples
   ```

2. **API**  
   From the `webapi` folder (where the `.sln` lives):

   ```bash
   dotnet run --project FIT_Api_Examples
   ```

   Note the URL and port (e.g. `https://localhost:7xxx`); Swagger is usually available at `/swagger` when enabled in development.

3. **Angular**  
   From the `angular_app` folder:

   ```bash
   npm install
   npm start
   ```

   Point the app at your API base URL in `src/environments/environment.ts` (and `environment.prod.ts` for production builds) so HTTP calls hit the running backend.

---

## How to use this for learning

- Start from **`Template 2024`** to understand the “clean” layout, then open **`Workshops/Ispitni …`** to see how specific features were implemented over the year.
- Trace a feature end to end: **component → service → HTTP → controller/endpoint → EF → SQL Server**.
- Keep **each workshop folder independent**—they duplicate the solution on purpose so you can diff two dates or roll back mentally without Git noise.

---

## Contributing / classroom use

This is an **academic tutoring** repository. If you fork or republish, keep connection strings and secrets out of Git; use `appsettings.Development.json`, user secrets, or environment variables locally.

---

## License

Unless otherwise noted by your institution, treat materials as **educational use**. Add an explicit license file if you need to formalize reuse.
