using Json.Schema;
using SchemaLib;
using System.Text.Json;
using System.Text.Json.Nodes;

Console.WriteLine("Workshop for JsonSchema\n\n");

Console.WriteLine("GENERATED SCHEMAS EXAMPLE");
var generatedSchemas = SchemaProviderGenerated.GetJsonSchemas("gen");
Console.WriteLine("Generator schemas is hard to maintain, they lack most of the keywords like $id $schema and such.\nTheir uri is not editable so it will be hard to distinguish and refer a schema\n");

foreach (var schema in generatedSchemas)
{
    Console.WriteLine($"Schema: Type: {schema.GetJsonType()} Uri: {schema.BaseUri}, $id: {schema.GetId()}");
    SchemaRegistry.Global.Register(schema);
}

var userShouldValidate = @"
 {
    ""id"": 1,
    ""name"": ""Leanne Graham"",
    ""username"": ""Bret"",
    ""email"": ""Sincere@april.biz"",
    ""address"": {
      ""street"": ""Kulas Light"",
      ""suite"": ""Apt. 556"",
      ""city"": ""Gwenborough"",
      ""zipcode"": ""92998-3874"",
      ""geo"": {
        ""lat"": ""-37.3159"",
        ""lng"": ""81.1496""
      }
    },
    ""phone!"": ""1-770-736-8031 x56442"",
    ""website"": ""hildegard.org"",
    ""company"": {
      ""name"": ""Romaguera-Crona"",
      ""catchPhrase"": ""Multi-layered client-server neural-net"",
      ""bs"": ""harness real-time e-markets""
    }
  }
";
/* quote from the documentation:
 * if the data isn’t valid, then a JsonException will be thrown. 
 * The validation results will be in the .Data dictionary on the exception under the "validation" key. 
 * (You’ll need to cast it to EvaluationResults.)
 */
Console.WriteLine("A validation for model User:");
Console.WriteLine(userShouldValidate);

try
{
    var myModel = JsonSerializer.Deserialize<Model.User>(userShouldValidate);
    var schema = generatedSchemas.First(s => $"{s.GetId()}" == "gen/Model.User");
    var jsonSchema = JsonSerializer.Serialize(schema);
    if (schema is null)
    {
        return;
    }

    var result = schema!.Evaluate(JsonNode.Parse(userShouldValidate));
    Console.WriteLine($"IsValid: {result.IsValid}");
}
catch (Exception)
{

    throw;
}

/*
 * The example is valid because schema lacks required fields so all fields
 * If we are gonna generate our own schemas we need to provide our validation rules as attributes
 * I dont like this approach because it is hard to maintain and it is not flexible
 * If im gonna create a schema dynamicaly i found that creating from builder is much easier than navigating through the each model of my own
 */

