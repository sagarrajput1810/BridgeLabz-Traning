using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPLAnalyzer
{
    public class MatchRecord
    {
        public int match_id { get; set; }
        public string team1 { get; set; } = "";
        public string team2 { get; set; } = "";
        public Dictionary<string,int> score { get; set; } = new();
        public string winner { get; set; } = "";
        public string player_of_match { get; set; } = "";
    }

    class Program
    {
        static string BasePath => AppDomain.CurrentDomain.BaseDirectory;

        static void Main()
        {
            Console.WriteLine("Running IPL Censorship Analyzer...");
            var jsonIn = Path.Combine(BasePath, "ipl_input.json");
            var csvIn = Path.Combine(BasePath, "ipl_input.csv");
            if (File.Exists(jsonIn)) ProcessJson(jsonIn);
            if (File.Exists(csvIn)) ProcessCsv(csvIn);
            Console.WriteLine("Censored outputs written to project folder.");
        }

        static string MaskTeamName(string team)
        {
            if (string.IsNullOrWhiteSpace(team)) return team;
            var parts = team.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1) return parts[0] + " ***";
            if (parts.Length == 2) return parts[0] + " ***";
            // keep first and last, mask middle
            return parts[0] + " *** " + parts[^1];
        }

        static void ProcessJson(string path)
        {
            var text = File.ReadAllText(path);
            var arr = JArray.Parse(text);
            var outArr = new JArray();
            foreach (var item in arr)
            {
                var obj = new JObject();
                obj["match_id"] = item["match_id"];
                var t1 = item["team1"]?.ToString() ?? "";
                var t2 = item["team2"]?.ToString() ?? "";
                var mt1 = MaskTeamName(t1);
                var mt2 = MaskTeamName(t2);
                obj["team1"] = mt1;
                obj["team2"] = mt2;
                // score object: map masked names to same scores
                var scoreObj = new JObject();
                foreach (var prop in ((JObject?)item["score"])?.Properties() ?? Enumerable.Empty<JProperty>())
                {
                    var originalName = prop.Name;
                    var masked = originalName == t1 ? mt1 : originalName == t2 ? mt2 : MaskTeamName(originalName);
                    scoreObj[masked] = prop.Value;
                }
                obj["score"] = scoreObj;
                var winner = item["winner"]?.ToString() ?? "";
                obj["winner"] = winner == t1 ? mt1 : winner == t2 ? mt2 : MaskTeamName(winner);
                obj["player_of_match"] = "REDACTED";
                outArr.Add(obj);
            }
            File.WriteAllText(Path.Combine(BasePath, "censored_ipl.json"), outArr.ToString(Formatting.Indented));
            Console.WriteLine("Wrote censored_ipl.json");
        }

        static void ProcessCsv(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<dynamic>().ToList();
            var outLines = new List<string>();
            // header
            outLines.Add("match_id,team1,team2,score_team1,score_team2,winner,player_of_match");
            foreach (IDictionary<string, object> rec in records)
            {
                var match_id = rec["match_id"]?.ToString() ?? "";
                var team1 = rec["team1"]?.ToString() ?? "";
                var team2 = rec["team2"]?.ToString() ?? "";
                var s1 = rec.ContainsKey("score_team1") ? rec["score_team1"]?.ToString() : rec.ContainsKey("score1") ? rec["score1"]?.ToString() : "";
                var s2 = rec.ContainsKey("score_team2") ? rec["score_team2"]?.ToString() : rec.ContainsKey("score2") ? rec["score2"]?.ToString() : "";
                var winner = rec["winner"]?.ToString() ?? "";
                var pom = rec["player_of_match"]?.ToString() ?? "";
                var mt1 = MaskTeamName(team1);
                var mt2 = MaskTeamName(team2);
                var mw = winner == team1 ? mt1 : winner == team2 ? mt2 : MaskTeamName(winner);
                var line = string.Join(',', new[] { match_id, mt1, mt2, s1, s2, mw, "REDACTED" });
                outLines.Add(line);
            }
            File.WriteAllLines(Path.Combine(BasePath, "censored_ipl_from_csv.csv"), outLines);
            Console.WriteLine("Wrote censored_ipl_from_csv.csv");
        }
    }
}
