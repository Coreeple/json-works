using Json.Schema;
using Json.Schema.Generation;
using Model;

namespace SchemaLib
{
    public static class SchemaProviderGenerated
    {
        public static IEnumerable<JsonSchema> GetJsonSchemas(string idPrefix)
        {
            var schemaBuilder = new JsonSchemaBuilder();
            List<JsonSchema> schemas = [
               schemaBuilder.FromType<Geo>().Id($"{idPrefix}/{typeof(Geo).FullName}").Build(),
               schemaBuilder.FromType<Address>().Id($"{idPrefix}/{typeof(Address).FullName}").Build(),
               schemaBuilder.FromType<Company>().Id($"{idPrefix}/{typeof(Company).FullName}").Build(),
               schemaBuilder.FromType<User>().Id($"{idPrefix}/{typeof(User).FullName}").Build(),
               schemaBuilder.FromType<Album>().Id($"{idPrefix}/{typeof(Album).FullName}").Build(),
               schemaBuilder.FromType<Comment>().Id($"{idPrefix}/{typeof(Comment).FullName}").Build(),
               schemaBuilder.FromType<Photo>().Id($"{idPrefix}/{typeof(Photo).FullName}").Build(),
               schemaBuilder.FromType<Post>().Id($"{idPrefix}/{typeof(Post).FullName}").Build(),
               schemaBuilder.FromType<Todo>().Id($"{idPrefix}/{typeof(Todo).FullName}").Build(),
                ];

            return schemas;
        }
    }
}
