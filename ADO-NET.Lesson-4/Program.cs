using System.Text;
using Library.Entities;
using Library.Repositories;


public static class Program {

  public static void Main(string[] args) {
    //IAuthorsRepository AuthorRepository = new LinqToObjectAuthorsRepository();
    //IBooksRepository BookRepository = getBookRepository();

    //List<Author> AuthorList = AuthorRepository.GetByFirstName("Adam");
    //WriteConsole(AuthorRepository.GetByFirstName("Adam"));

    //foreach (Author author in AuthorList) {
    //  Console.WriteLine($"{author.FirstName} {BookRepository.GetBookCount(author.Id)}");
    //}

    //string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //List<Book> books = DataStorage.GetBooks(connString);


    Console.ReadLine();
  }

  private static IBooksRepository getBookRepository() {
    return new LinqToBooksRepository();
  }

  private static void WriteConsole(List<Author> authors) {
    var columnLength = new[] { 3, 10, 10, 40 };
    Console.WriteLine(GetBound(columnLength));
    foreach (Author author in authors) {

      Console.WriteLine(GetLine(author, columnLength));
      Console.WriteLine(GetBound(columnLength));
    }
  }

  private static string GetBound(int[] ints) {
    return $"+{GetReplyItems(ints[0], '-')}" +
           $"+{GetReplyItems(ints[1], '-')}" +
           $"+{GetReplyItems(ints[2], '-')}" +
           $"+{GetReplyItems(ints[3], '-')}+";
  }

  private static string GetLine(Author author, int[] ints) {
    return $"|{author.Id}{GetSpaces(ints[0] - author.Id.ToString().Length)}" +
        $"|{author.FirstName}{GetSpaces(ints[1] - (author.FirstName?.Length ?? 0))}" +
        $"|{author.LastName}{GetSpaces(ints[2] - (author.LastName?.Length ?? 0))}" +
        $"|{author.Comment}{GetSpaces(ints[3] - (author.Comment?.Length ?? 0))}|";
  }

  private static string GetSpaces(int count) {
    return GetReplyItems(count, ' ');
  }

  private static string GetReplyItems(int count, char item) {
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < count; i++) {
      sb.Append(item);
    }

    return sb.ToString();
  }
}