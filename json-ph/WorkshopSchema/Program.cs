using WorkshopSchema;

Console.WriteLine("Workshop for JsonSchema\n\n");

//// Generator Schema Examples suitable for basic usage
//GeneratorSchemaExamples.PrintSchemas();
//GeneratorSchemaExamples.ValidationExample();

// Schema Examples suitable for advanced usage
SchemaExamples.PrintSchemas();
SchemaExamples.ValidationExample("User", "user.alt.json");
