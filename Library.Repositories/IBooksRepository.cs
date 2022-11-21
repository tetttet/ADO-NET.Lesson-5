using Library.Entities;
namespace Library.Repositories;

public interface IBooksRepository {
  int GetBookCount(int authorId);
  List<Book> GetBookWithOutComment(int _id);
  List<Book> GetBooksAuthor(int authorId);
  List<Book> GetBooksType(int typeid);
  List<Book> GetBooksGenre(int genreid);
}

public class LinqToBooksRepository : IBooksRepository {
  public int GetBookCount(int authorId) {
    List<Book> books = new List<Book>();

    IEnumerable<Book>? _list = from book in books
                               where book.AuthorId == authorId
                               select book;

    return _list.Count();
  }
  public List<Book> GetBookWithOutComment(int _id) {
    List<Book> library = DataStorage.GetBooks();

    for (int _bookElIndex = 0; _bookElIndex < library.Count; _bookElIndex++) {
      if (library[_bookElIndex].Comment != null) {
        library[_bookElIndex].Comment = null; // it can be ?null
      }
    }
    return library;
  }
  public List<Book> GetBooksAuthor(int authorId) {
    return DataStorage.GetBooks().Where(book => book.AuthorId == authorId).ToList();
  }
  public List<Book> GetBooksType(int typeid) {
    return DataStorage.GetBooks().Where(book => book.TypeId == typeid).ToList();
  }
  public List<Book> GetBooksGenre(int genreid) {
    return DataStorage.GetBooks().Where(book => book.GenreId == genreid).ToList();
  }

}

