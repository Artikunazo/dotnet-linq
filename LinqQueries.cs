public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
    public IEnumerable<Book> AllCollection() {
        return booksCollection;
    }

    public IEnumerable<Book> booksAfter2000() {
        // Extension Method
        // return booksCollection.Where(book => book.PublishedDate.Year > 2000);
        
        // Query expressionm
        return from book in booksCollection where book.PublishedDate.Year >= 2000 select book;
    }
    public IEnumerable<Book> bookCount250PagesAndTitleInAction() {
        // Extension methods
        // return booksCollection.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));

        // Query Expression
        return from book in booksCollection where book.PageCount > 250 && book.Title.Contains("in Action") select book;
    }

}
