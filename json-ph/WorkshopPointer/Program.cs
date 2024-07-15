using System.Text.Json;
using WorkshopPointer;

var jsopt = new JsonSerializerOptions();
jsopt.WriteIndented = true;

Console.WriteLine("Workshop for JsonPointer practices!");

var bookstoreJsonFP = @"../../../../Examples/Pointer/bookstore.json";
var bsx = new BookStoreExample(bookstoreJsonFP);
bsx.EmployeeLookUp();
bsx.BooksLookUp();
bsx.FilterBooksByPrice(10.0);
bsx.FilterBooksByPrice(20.0);
bsx.RelativeFilterBooksByPrice(20.0);

// borrowed from https://json-schema.org/draft/2020-12/relative-json-pointer#rfc.section.5.1
var nestedJsonFP = @"../../../../Examples/Pointer/nested-objects.json";
var nsx = new NestedObjectsExample(nestedJsonFP);


string[] pointersFromFooBaz = ["0", "1/0", "0", "1/0", "0-1", "2/highly/nested/objects", "0#", "0-1#", "1#"];
nsx.PrintDoc();
Console.WriteLine("\nStarting from the value 'baz' (inside 'foo')\n");
foreach (var p in pointersFromFooBaz)
{
    nsx.FooBaz(p);
}

nsx.PrintDoc();
List<string> pointersFromNestedObj = ["0/objects", "1/nested/objects", "2/foo/0", "0#", "1#"];
Console.WriteLine(@"Starting from the value {""objects"":true} (corresponding to the member key ""nested"")");

pointersFromNestedObj.ForEach(p => nsx.Nested(p));

