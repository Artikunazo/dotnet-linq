public class LinqQueries
{
  private readonly List<Book> booksCollection = new List<Book>();
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

  public IEnumerable<Book> BooksAfter2000() {
      // Extension Method
      // return booksCollection.Where(book => book.PublishedDate.Year > 2000);
      
      // Query expressionm
      return from book in booksCollection 
        where book.PublishedDate.Year >= 2000 
        select book;
  }
  public IEnumerable<Book> BookCount250PagesAndTitleInAction() {
      // Extension methods
      // return booksCollection.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));

      // Query Expression
      return from book in booksCollection 
        where book.PageCount > 250 && book.Title.Contains("in Action") 
        select book;
  }

  public bool AllBooksHasStatus() {
    return booksCollection.All(book => book.Status != string.Empty);
  }

  public bool AnyBookWasPublishIn2005() {
    return booksCollection
      .Any(book => book.PublishedDate.Year == 2005);
  }

  public IEnumerable<Book> BooksPython() {
    return booksCollection
      .Where(book => book.Categories.Contains("Python"));
  }

  public IEnumerable<Book> BooksJava() {
    return booksCollection
      .Where(book => book.Categories.Contains("Java"))
      .OrderBy(book => book.Title);
  }

  public IEnumerable<Book> BooksWith450PagesOrMore() {
    return booksCollection
      .Where(book => book.PageCount >= 450)
      .OrderByDescending(book => book.PageCount);
  }

  public IEnumerable<Book> Take3FirstRecentBooksInJavaCategory() {
    // return booksCollection
    //   .Where(book => book.Categories.Contains("Java"))
    //   .OrderByDescending(book => book.PublishedDate)
    //   .Take(3);

    return booksCollection
      .Where(book => book.Categories.Contains("Java"))
      .OrderBy(book => book.PublishedDate)
      .TakeLast(3);
  }

  public IEnumerable<Book> Take3and4BookWith400PagesOrMore() {
    return booksCollection
      .Where(book => book.PageCount > 400)
      .Take(4)
      .Skip(2);
  }

  public IEnumerable<Book> First3BooksOfCollection() {
    return booksCollection
      .Take(3)
      .Select(book => new Book() {Title = book.Title, PageCount = book.PageCount});
  }

  public long CountBooksWith200And500Pages() {
    // return booksCollection
    //   .Where(book => book.PageCount >= 200 && book.PageCount <= 500)
    //   .LongCount();

    // This way has better performance
     return booksCollection
      .LongCount(book => book.PageCount >= 200 && book.PageCount <= 500);
  }

  public DateTime MinPublishedDate() {
    return booksCollection.Min(book => book.PublishedDate);
  }

  public int MaxPagesInTheCollection() {
    return booksCollection.Max(book => book.PageCount);
  }

}
