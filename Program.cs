LinqQueries queries = new LinqQueries();
var printStructure = "{0, -60} {1, 12} {2, 11}\n";

void PrintValues(IEnumerable<Book> listBooks) {
    Console.WriteLine(printStructure, "Title", "N. Pages", "Published");
    foreach(var item in listBooks) {
        Console.WriteLine(printStructure, item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
} 

// All Colletcion
// PrintValues(queries.AllCollection());

// Books after 2000
// PrintValues(queries.booksAfter2000());

// Books with 250 pages or more and title has "In Action"
PrintValues(queries.bookCount250PagesAndTitleInAction());
