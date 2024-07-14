using Json.Schema;

namespace SchemaLib
{
    public static class SchemaProviderFile
    {
        public static IEnumerable<JsonSchema> GetJsonSchemas(string path, string searchPattern)
        {
            var schemaFiles = Directory.GetFiles(path, searchPattern);
            foreach (var schemaFile in schemaFiles)
            {
                var schema = JsonSchema.FromFile(schemaFile);
                yield return schema;
            }
        }
    }
}
