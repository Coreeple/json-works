using Json.Pointer;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WorkshopPointer
{
    internal class BookStoreExample
    {
        private JsonNode JsonDoc { get; set; }
        private JsonPointer StoreP { get; set; }
        private JsonPointer EmployeeP { get; set; }
        private JsonSerializerOptions Jsopt { get; set; }

        public BookStoreExample(string filePath)
        {
            var doc = File.ReadAllText(filePath);

            JsonDoc = JsonNode.Parse(doc);
            StoreP = JsonPointer.Parse("/store");
            EmployeeP = JsonPointer.Parse("/employees");
            Jsopt = new JsonSerializerOptions();
            Jsopt.WriteIndented = true;
        }

        public void RelativeFilterBooksByPrice(double lessThan)
        {
            Console.WriteLine("\nRelative Filter Books by Price Example");
            List<JsonNode> books = [];
            List<JsonPointer> booksFilterP = [];
            for (int i = 0; i < 3; i++)
            {
                var bookPrice = StoreP.Combine("books", i, "price");
                if (!bookPrice.TryEvaluate(JsonDoc, out var price))
                {
                    Console.WriteLine($"price not found at {i}");
                }

                if (price is not null && ((double)price) < lessThan)
                {
                    var bookP = RelativeJsonPointer.Parse("1");
                    if (bookP.TryEvaluate(price, out var book) && book is not null)
                    {
                        books.Add(book);
                    }
                }
            }
            Console.WriteLine($"Found {books.Count} books with price less than {lessThan}");

            foreach (var book in books)
            {
                Console.WriteLine(book.ToJsonString(Jsopt));
            }
            Console.WriteLine();

        }

        public void FilterBooksByPrice(double lessThan)
        {
            Console.WriteLine("\nFilter Books by Price Example");
            List<JsonNode> books = [];
            List<JsonPointer> booksFilterP = [];
            for (int i = 0; i < 3; i++)
            {
                var bookPrice = StoreP.Combine("books", i, "price");
                if (!bookPrice.TryEvaluate(JsonDoc, out var price))
                {
                    Console.WriteLine($"price not found at {i}");
                }

                if (price is not null && ((double)price) < lessThan)
                {
                    booksFilterP.Add(bookPrice[..^1]); // remove the last segment to reach book
                }
            }
            foreach (var bookP in booksFilterP)
            {
                if (bookP.TryEvaluate(JsonDoc, out var book) && book is not null)
                {
                    books.Add(book);
                }
            }
            Console.WriteLine($"Found {books.Count} books with price less than {lessThan}");

            foreach (var book in books)
            {
                Console.WriteLine(book.ToJsonString(Jsopt));
            }
            Console.WriteLine();
        }

        public void BooksLookUp()
        {
            Console.WriteLine("\nBook Lookup Example");
            for (int i = 0; i < 3; i++)
            {
                var bookTitle = StoreP.Combine("books", i, "title");
                var bookPrice = StoreP.Combine("books", i, "price");
                var bookYear = StoreP.Combine("books", i, "publication", "year");
                if (!bookTitle.TryEvaluate(JsonDoc, out var title))
                {
                    Console.WriteLine($"title not found at {i}");
                }

                if (!bookPrice.TryEvaluate(JsonDoc, out var price))
                {
                    Console.WriteLine($"price not found at {i}");
                }

                if (!bookYear.TryEvaluate(JsonDoc, out var year))
                {
                    Console.WriteLine($"year not found at {i}");
                }
                Console.WriteLine($"Book {i + 1}: {title} [{year}] is priced at {price}");
            }
        }

        public void EmployeeLookUp()
        {
            Console.WriteLine("\nEmployee Lookup example");
            for (int i = 0; i < 2; i++)
            {
                var employeeName = EmployeeP.Combine(i, "name");
                var employeeRole = EmployeeP.Combine(i, "role");
                if (!employeeName.TryEvaluate(JsonDoc, out var name))
                {
                    Console.WriteLine($"name not found at {i}");
                }

                if (!employeeRole.TryEvaluate(JsonDoc, out var role))
                {
                    Console.WriteLine($"role not found at {i}");
                }

                Console.WriteLine($"Employee {i + 1}: {name} is a {role}");
            }
        }
    }
}
