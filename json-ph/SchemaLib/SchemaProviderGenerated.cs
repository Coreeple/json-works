using Json.Schema;
using Json.Schema.Generation;
using Model;

namespace SchemaLib
{
    public static class SchemaProviderGenerated
    {
        public static IEnumerable<JsonSchema> GetJsonSchemas()
        {
            var schemaBuilder = new JsonSchemaBuilder();
            List<JsonSchema> schemas = [
               schemaBuilder.FromType<Geo>().Build(),
               schemaBuilder.FromType<Address>().Build(),
               schemaBuilder.FromType<Company>().Build(),
               schemaBuilder.FromType<User>().Build(),
               schemaBuilder.FromType<Album>().Build(),
               schemaBuilder.FromType<Comment>().Build(),
               schemaBuilder.FromType<Photo>().Build(),
               schemaBuilder.FromType<Post>().Build(),
               schemaBuilder.FromType<Todo>().Build(),
                ];

            return schemas;
        }
    }
}
