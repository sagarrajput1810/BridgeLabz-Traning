using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonPractice
{
    class Car { public string Make { get; set; } = ""; public string Model { get; set; } = ""; public int Year { get; set; } }

    class Person { public string name { get; set; } = ""; public int age { get; set; } public string email { get; set; } = ""; }

    class Program
    {
        static string BasePath => AppDomain.CurrentDomain.BaseDirectory;

        static void Main()
        {
            Console.WriteLine("Running JSON practice examples...");
            BasicStudentJson();
            CarToJson();
            ReadJsonExtractFields();
            MergeJsonObjects();
            ValidateJsonWithSchema();
            ListToJsonArray();
            FilterAgeGreaterThan25();
            Console.WriteLine("Done. Check project folder for sample outputs.");
        }

        static void BasicStudentJson()
        {
            var student = new {
                name = "Alice",
                age = 23,
                subjects = new[] { "Math", "Physics", "CS" }
            };
            var json = JsonConvert.SerializeObject(student, Formatting.Indented);
            File.WriteAllText(Path.Combine(BasePath, "student.json"), json);
            Console.WriteLine("Wrote student.json");
        }

        static void CarToJson()
        {
            var car = new Car { Make = "Toyota", Model = "Camry", Year = 2020 };
            var json = JsonConvert.SerializeObject(car, Formatting.Indented);
            File.WriteAllText(Path.Combine(BasePath, "car.json"), json);
            Console.WriteLine("Wrote car.json");
        }

        static void ReadJsonExtractFields()
        {
            var sample = File.ReadAllText(Path.Combine(BasePath, "sample_input.json"));
            var arr = JArray.Parse(sample);
            var outList = new List<object>();
            foreach (var item in arr)
            {
                outList.Add(new { name = item["name"], email = item["email"] });
            }
            File.WriteAllText(Path.Combine(BasePath, "extracted_fields.json"), JsonConvert.SerializeObject(outList, Formatting.Indented));
            Console.WriteLine("Wrote extracted_fields.json");
        }

        static void MergeJsonObjects()
        {
            var a = JObject.Parse("{ 'a':1, 'x': 10 }");
            var b = JObject.Parse("{ 'b':2, 'x': 20 }");
            a.Merge(b, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
            File.WriteAllText(Path.Combine(BasePath, "merged.json"), a.ToString(Formatting.Indented));
            Console.WriteLine("Wrote merged.json");
        }

        static void ValidateJsonWithSchema()
        {
            var schemaJson = @"{
  'type': 'object',
  'properties': {
    'name': {'type':'string'},
    'email': {'type':'string','format':'email'}
  },
  'required':['name','email']
}";
            var schema = JSchema.Parse(schemaJson);
            var sample = File.ReadAllText(Path.Combine(BasePath, "sample_input.json"));
            var arr = JArray.Parse(sample);
            var results = new List<object>();
            foreach (var item in arr)
            {
                bool valid = item.IsValid(schema, out IList<string>? errors);
                results.Add(new { name = item["name"], email = item["email"], valid, errors });
            }
            File.WriteAllText(Path.Combine(BasePath, "schema_validation.json"), JsonConvert.SerializeObject(results, Formatting.Indented));
            Console.WriteLine("Wrote schema_validation.json");
        }

        static void ListToJsonArray()
        {
            var cars = new List<Car> {
                new Car{ Make = "Honda", Model = "Civic", Year = 2019},
                new Car{ Make = "Ford", Model = "Focus", Year = 2018}
            };
            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText(Path.Combine(BasePath, "cars_array.json"), json);
            Console.WriteLine("Wrote cars_array.json");
        }

        static void FilterAgeGreaterThan25()
        {
            var sample = File.ReadAllText(Path.Combine(BasePath, "sample_input.json"));
            var arr = JArray.Parse(sample);
            var filtered = new JArray();
            foreach (var item in arr)
            {
                if ((int?)item["age"] > 25) filtered.Add(item);
            }
            File.WriteAllText(Path.Combine(BasePath, "filtered_age_gt_25.json"), filtered.ToString(Formatting.Indented));
            Console.WriteLine("Wrote filtered_age_gt_25.json");
        }
    }
}
