# JSON practice and IPL Analyzer

Two small .NET console projects are added under this folder:

- `JsonPractice` — examples for the Basic JSON Handling and Hands-on practice problems. It writes sample outputs into the project folder.
- `IPLAnalyzer` — reads IPL match data from JSON and CSV, masks team names and redacts `player_of_match`, then writes censored outputs.

Build & run (from parent directory `.../JSON`):

```bash
cd JsonPractice
dotnet build
dotnet run

cd ../IPLAnalyzer
dotnet build
dotnet run
```

Outputs:
- `JsonPractice` writes `student.json`, `car.json`, `extracted_fields.json`, `merged.json`, `schema_validation.json`, `cars_array.json`, `filtered_age_gt_25.json`.
- `IPLAnalyzer` writes `censored_ipl.json` and `censored_ipl_from_csv.csv` in its project folder.
