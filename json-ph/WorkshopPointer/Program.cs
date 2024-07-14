using Json.Pointer;
using System.Text.Json;
using System.Text.Json.Nodes;

var jsopt = new JsonSerializerOptions();
jsopt.WriteIndented = true;

Console.WriteLine("Workshop for JsonPointer practices!");

var filePath = @"../../../../Examples/Pointer/bookstore.json";
var doc = File.ReadAllText(filePath);

var jsonDoc = JsonNode.Parse(doc);

var storeP = JsonPointer.Parse("/store");
var employeeP = JsonPointer.Parse("/employees");

ExEmployeeLookUp();
ExBooksLookUp();
ExFilterBooksByPrice(10.0);
ExFilterBooksByPrice(20.0);

void ExFilterBooksByPrice(double lessThan)
{
    Console.WriteLine("\nFilter Books by Price Example");
    List<JsonNode> books = [];
    List<JsonPointer> booksFilterP = [];
    for (int i = 0; i < 3; i++)
    {
        var bookPrice = storeP.Combine("books", i, "price");
        if (!bookPrice.TryEvaluate(jsonDoc, out var price))
        {
            Console.WriteLine($"price not found at {i}");
        }

        if (price is not null && ((double)price) < lessThan)
        {
            booksFilterP.Add(bookPrice[..^1]); // remove the last two segments to reach book
        }
    }
    foreach (var bookP in booksFilterP)
    {
        if (bookP.TryEvaluate(jsonDoc, out var book) && book is not null)
        {
            books.Add(book);
        }
    }
    Console.WriteLine($"Found {books.Count} books with price less than {lessThan}");

    foreach (var book in books)
    {
        Console.WriteLine(book.ToJsonString(jsopt));
    }
    Console.WriteLine();
}

void ExBooksLookUp()
{
    Console.WriteLine("\nBook Lookup Example");
    for (int i = 0; i < 3; i++)
    {
        var bookTitle = storeP.Combine("books", i, "title");
        var bookPrice = storeP.Combine("books", i, "price");
        var bookYear = storeP.Combine("books", i, "publication", "year");
        if (!bookTitle.TryEvaluate(jsonDoc, out var title))
        {
            Console.WriteLine($"title not found at {i}");
        }

        if (!bookPrice.TryEvaluate(jsonDoc, out var price))
        {
            Console.WriteLine($"price not found at {i}");
        }

        if (!bookYear.TryEvaluate(jsonDoc, out var year))
        {
            Console.WriteLine($"year not found at {i}");
        }
        Console.WriteLine($"Book {i + 1}: {title} [{year}] is priced at {price}");
    }
}

void ExEmployeeLookUp()
{
    Console.WriteLine("\nEmployee Lookup example");
    for (int i = 0; i < 2; i++)
    {
        var employeeName = employeeP.Combine(i, "name");
        var employeeRole = employeeP.Combine(i, "role");
        if (!employeeName.TryEvaluate(jsonDoc, out var name))
        {
            Console.WriteLine($"name not found at {i}");
        }

        if (!employeeRole.TryEvaluate(jsonDoc, out var role))
        {
            Console.WriteLine($"role not found at {i}");
        }

        Console.WriteLine($"Employee {i + 1}: {name} is a {role}");
    }
}
