using Json.Pointer;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WorkshopPointer
{
    internal class NestedObjectsExample
    {
        private JsonNode JsonDoc { get; set; }
        private JsonSerializerOptions Jsopt { get; set; }
        private JsonPointer FooBazP { get; } = JsonPointer.Parse("/foo/1");
        private JsonPointer NestedP { get; } = JsonPointer.Parse("/highly/nested");
        public NestedObjectsExample(string filePath)
        {
            var doc = File.ReadAllText(filePath);
            JsonDoc = JsonNode.Parse(doc);

            Jsopt = new JsonSerializerOptions();
            Jsopt.WriteIndented = true;

            Console.WriteLine(JsonDoc.ToJsonString(Jsopt));
        }

        public void FooBaz(string relativePointer)
        {
            var pointer = RelativeJsonPointer.Parse(relativePointer);
            string value = "null";

            if (pointer is not null && FooBazP.TryEvaluate(JsonDoc, out var fooBaz)
                && fooBaz is not null)
            {
                if (pointer.TryEvaluate(fooBaz, out JsonNode? node) && node is not null) {
                    value = node.ToJsonString(Jsopt); 
                };
            }
            Console.WriteLine($"Pointer: {relativePointer}\t{value}");
        }

        public void Nested(string relativePointer)
        {
            var pointer = RelativeJsonPointer.Parse(relativePointer);
            string value = "null";

            if (pointer is not null && NestedP.TryEvaluate(JsonDoc, out var fooBaz)
                && fooBaz is not null)
            {
                if (pointer.TryEvaluate(fooBaz, out JsonNode? node) && node is not null) {
                    value = node.ToJsonString(Jsopt); 
                };
            }
            Console.WriteLine($"Pointer: {relativePointer}\t{value}");
        }
        public void PrintDoc()
        {
            Console.WriteLine(JsonDoc.ToJsonString(Jsopt));
        }
    }
}
