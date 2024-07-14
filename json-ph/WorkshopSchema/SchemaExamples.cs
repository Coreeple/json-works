using Json.Schema;
using SchemaLib;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WorkshopSchema
{
    public static class SchemaExamples
    {
        static List<JsonSchema> _schemas = [.. SchemaProviderFile.GetJsonSchemas(@"../../../../Model/Schemas/", "*.json")];
        public static void PrintSchemas()
        {

            Console.WriteLine("SCHEMAS EXAMPLE");
            Console.WriteLine("Schemas are easy to maintain, they have all the keywords like $id $schema and such.\nTheir uri is editable so it will be easy to distinguish and refer a schema\n");
            foreach (var schema in _schemas)
            {
                Console.WriteLine($"Schema: Type: {schema.GetJsonType()}\nUri: {schema.BaseUri}\n$id: {schema.GetId()}\n");
            }
        }

        public static void ValidationExample(string exampleFolder, string modelName)
        {
            var options = new EvaluationOptions();
            var schema = _schemas.First(s => $"{s.GetId()}" == "https://github.com/Coreeple/json-works/json-ph/Model/Schemas/" + modelName);
            var exampleFiles = Directory.GetFiles(@$"../../../../examples/{exampleFolder}/", "*.json");
            foreach (var example in exampleFiles)
            {
                var fileContent = File.ReadAllText(example);
                options.OutputFormat = OutputFormat.List;
                var result = schema!.Evaluate(JsonNode.Parse(fileContent), options: options);
                PrintResult(result);
            }

        }

        public static void PrintResult(EvaluationResults? results)
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat('\n',3)));
            if (results is null)
            {
                return;
            }
            Console.WriteLine(string.Concat(Enumerable.Repeat('#', 40)));
            if (results.IsValid)
            {
                Console.WriteLine("The data is valid");
                Console.WriteLine(string.Concat(Enumerable.Repeat('#', 40)));
                return;
            }
            var details = JsonSerializer.Serialize(results.Details.Where(d => !d.IsValid), new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(details);
            Console.WriteLine(string.Concat(Enumerable.Repeat('#', 40)));
        }
    }
}
