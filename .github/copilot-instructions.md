<!-- .github/copilot-instructions.md - guidance for AI coding agents working in this repo -->
# Copilot instructions for BridgeLabz-Traning

This repository contains many small C# console projects, practice exercises, and unit-test projects grouped under `core-csharp-practice`. The guidance below captures the repository structure, common workflows, conventions, and concrete examples an AI assistant should use when making, testing, or running changes.

## Big picture
- Top-level: many self-contained .NET console apps and test projects (no single monolithic app).
- Primary learning workspace: [core-csharp-practice](core-csharp-practice) — it houses topic folders (Collections, JSON, DSA, Regex, Testing, scenario-based, etc.).
- Each exercise/project is a standalone .NET project (has its own .csproj). Changes should be limited to the smallest project that needs them.

## How projects are organized
- Topic folders (e.g. [core-csharp-practice/gcr-codebase/JSON](core-csharp-practice/gcr-codebase/JSON)) contain one or more project folders. Each project is runnable via `dotnet`.
- Tests live alongside their targets using the `*.Tests` naming convention (e.g. `PasswordValidator.Tests`).
- Sample input files (CSV/JSON) are placed in the project folder (see [core-csharp-practice/gcr-codebase/CSVFile/Sample.csv](core-csharp-practice/gcr-codebase/CSVFile/Sample.csv)).

## Build / Run / Test (concrete commands)
- Build and run a single project (from the project folder):

```powershell
cd core-csharp-practice\gcr-codebase\JSON\JsonPractice
dotnet build
dotnet run
```

- Run tests for a test project:

```powershell
cd core-csharp-practice\gcr-codebase\Testing\PasswordValidatorApp\PasswordValidator.Tests
dotnet test
```

- To run a scenario app (example):

```powershell
cd core-csharp-practice\scenario-based\RobotHazardAuditor
dotnet run
```

Notes: the repository does not contain a global solution (.sln) to build everything at once — operate at the project folder level.

## Repository conventions & patterns
- Each console app typically exposes a `Program.cs` entry-point and writes outputs (reports, filtered files) into its own project folder.
- Tests follow xUnit/NUnit style and are placed in `*.Tests` projects; use `dotnet test` in that test folder.
- Naming: descriptive folders like `RegexPractice`, `IPLAnalyzer`, `JsonPractice` indicate intent — prefer to keep changes within the same folder unless cross-cutting.

## Integration points & sample files
- CSV handling utilities: [core-csharp-practice/gcr-codebase/CSVFile](core-csharp-practice/gcr-codebase/CSVFile) — sample CSV: `Sample.csv` used by CSV utilities.
- JSON examples and analyzers: [core-csharp-practice/gcr-codebase/JSON/IPLAnalyzer](core-csharp-practice/gcr-codebase/JSON/IPLAnalyzer) — see README for build/run examples.

## Helpful file references (examples to inspect before editing)
- [core-csharp-practice/scenario-based/RobotHazardAuditor/Program.cs](core-csharp-practice/scenario-based/RobotHazardAuditor/Program.cs)
- [core-csharp-practice/gcr-codebase/JSON/JsonPractice/JsonPractice.csproj](core-csharp-practice/gcr-codebase/JSON/JsonPractice/JsonPractice.csproj)
- [core-csharp-practice/gcr-codebase/CSVFile/ReadCSV.cs](core-csharp-practice/gcr-codebase/CSVFile/ReadCSV.cs)
- [core-csharp-practice/gcr-codebase/Regex/RegexPractice/RegexPractice.csproj](core-csharp-practice/gcr-codebase/Regex/RegexPractice/RegexPractice.csproj)

## Guidance for editing and PRs
- Make minimal, local changes scoped to one project folder when possible.
- After changes, run `dotnet build` and `dotnet run` for the targeted project, and run any related `*.Tests` with `dotnet test`.
- When adding dependencies, update the project `.csproj` and verify `dotnet build` succeeds.

## What not to assume
- There's no centralized CI config or single solution file — do not assume `dotnet build` at repo root will build everything.
- Do not assume database or network services are available — most projects operate on local sample files.

## When you need clarification
- Ask which specific project the user wants to modify, and whether they want changes applied across multiple exercises.
- If a change affects many folders, request permission before making wide-reaching edits.

---
If anything here is unclear or you'd like more examples (for a particular project), tell me which folder or file to expand and I'll iterate. 
