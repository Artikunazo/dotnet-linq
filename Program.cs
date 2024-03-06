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
// PrintValues(queries.BookCount250PagesAndTitleInAction());

// All Books has status
// Console.WriteLine($"Has all books status? {queries.AllBooksHasStatus()}");

// Any book was publish in 2005
// Console.WriteLine($"Any book was published in 2005? {queries.AnyBookWasPublishIn2005()}");

// Show books python
// PrintValues(queries.BooksPython());

// Show Java books
// PrintValues(queries.BooksJava());

// Show books with 450 pages or more
// PrintValues(queries.BooksWith450PagesOrMore());

// Show 3 first recent books in Java category
// PrintValues(queries.Take3FirstRecentBooksInJavaCategory());

// Show 3rd and 4th books with 400 pages or more
// PrintValues(queries.Take3and4BookWith400PagesOrMore());

// Show 3 first books of all collection
// PrintValues(queries.First3BooksOfCollection());

// Show how many books has between 200 and 500 pages
// Console.WriteLine($"How many books has 200 and 500 pages? {queries.CountBooksWith200And500Pages()}");

// SHow Min Published date
// Console.WriteLine($"Min published date {queries.MinPublishedDate()}");

// Show max pages in the collection
Console.WriteLine($"Max pages in the collection: {queries.MaxPagesInTheCollection()}");
