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


