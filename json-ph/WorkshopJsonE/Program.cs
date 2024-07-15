using Json.JsonE;
using System.Text.Json;
using System.Text.Json.Nodes;

//must visit https://json-e.js.org/introduction.html
var opt = new JsonSerializerOptions();
opt.WriteIndented = true;

Console.WriteLine("Workshop for JSON-E!");
StringInterpolation();
Operators();
Expressions(); 

ExampleFromFile(@"../../../../Examples/jsonE/user.json");

void PrintResults(JsonNode? template, JsonNode? context)
{
    var result = JsonE.Evaluate(template, context);
    Console.WriteLine($"\nTemplate: {template!.ToJsonString(opt)}");
    Console.WriteLine($"Context : {context!.ToJsonString(opt)}");
    Console.WriteLine($"Result  : {result!.ToJsonString(opt)}\n");
}

void ExampleFromFile(string filePath) {
    Console.WriteLine($"Example from file: {filePath}");
    var doc = JsonNode.Parse(File.ReadAllText(filePath));
    var template = doc["template"];
    var context = doc["context"];
    PrintResults(template, context);
}

void StringInterpolation()
{
    Console.WriteLine("String Interpolation example");
    var template = JsonNode.Parse("{\"message\": \"hello ${key}\", \"k=${num}\": true}");
    var context = JsonNode.Parse("{\"key\": \"world\", \"num\": 1}")!.AsObject();

    PrintResults(template, context);
}

void Operators()
{
    Console.WriteLine("Operators Example");
    var template = JsonNode.Parse(
        "{\"$flatten\": [[1, 2], [3, 4], [5]]}"
    );

    var context = JsonNode.Parse("{}")!.AsObject();

    // result: [1, 2, 3, 4, 5]
    PrintResults(template, context);
}

void Expressions()
{
    Console.WriteLine("Expressions example");

    var template = JsonNode.Parse(
        "{\"$eval\": \"(z / x) ** 2\"}"
    );
    var context = JsonNode.Parse(
        "{\"x\": 10, \"z\": 20, \"s\": \"face\", \"t\": \"plant\"}"
    )!.AsObject();

    PrintResults(template, context);
}