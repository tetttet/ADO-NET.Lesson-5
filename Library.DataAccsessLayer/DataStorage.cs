using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Library.Entities;

public static class DataStorage {
  public const string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

  public static List<Author> GetAuthors() {
    return new List<Author>()
    {
            new Author() { Id = 1, FirstName = "Adam", LastName = "Brown", Comment = null },
            new Author() { Id = 1, FirstName = "Adam", LastName = "Brown", Comment = "Duplicate to 1" },
            new Author() { Id = 1, FirstName = "Adam", LastName = "Clark", Comment = "Adam 3" },
            new Author() { Id = 1, FirstName = "Adam", LastName = "Lee", Comment = "Adam4" },
            new Author() { Id = 1, FirstName = "David", LastName = "Clark", Comment = null },
            new Author() { Id = 1, FirstName = "David", LastName = "Hall", Comment = null },
            new Author() { Id = 1, FirstName = "David", LastName = "Wood", Comment = "This is David Wood" },
            new Author() { Id = 1, FirstName = "Jack", LastName = "Lee", Comment = "This is lagest comment of all list" },
            new Author() { Id = 1, FirstName = "Martin", LastName = "Brown", Comment = "" },
            new Author() { Id = 1, FirstName = "Martin", LastName = "Hall", Comment = "" },
            new Author() { Id = 1, FirstName = "Martin", LastName = "Lee", Comment = "" },
            new Author() { Id = 1, FirstName = "Martin", LastName = "Rogers", Comment = "" },
            new Author() { Id = 1, FirstName = "Travis", LastName = "Rogers", Comment = "" },
            new Author() { Id = 1, FirstName = "Travis", LastName = null, Comment = "" },
            new Author() { Id = 1, FirstName = "William", LastName = "Wood", Comment = "This is William Wood" },
            new Author() { Id = 1, FirstName = "William", LastName = null, Comment = "" },
        };
  }

  public static List<Book> GetBooks(string _connectionString = connString) {
    List<Book> books = new List<Book>();

    using (SqlConnection connection = new SqlConnection(_connectionString))
    using (SqlCommand command = new SqlCommand("select * from Books", connection)) {
      connection.Open();
      using (SqlDataReader reader = command.ExecuteReader()) {
        while (reader.Read()) {

          Book? _object = new Book();
          _object.BookId = Convert.ToInt32(reader["Id"]);
          _object.AuthorId = Convert.ToInt32(reader["AuthorId"]);
          _object.Name = reader["Name"].ToString();
          _object.PageCount = Convert.ToInt32(reader["PageCount"]);
          _object.Publishing = Convert.ToInt32(reader["PublishingYear"]);
          _object.TypeId = Convert.ToInt32(reader["TypeId"]);
          _object.Comment = reader["Comment"].ToString();
          _object.GenreId = Convert.ToInt32(reader["GenreId"]);

          books.Add(_object);
        }
      }
    }
    return books;
  }

  public static List<Reader> GetReaders(string _connectionString = connString) {
    List<Reader> books = new List<Reader>();

    using (SqlConnection connection = new SqlConnection(_connectionString))
    using (SqlCommand command = new SqlCommand("select * from Readers", connection)) {
      connection.Open();
      using (SqlDataReader reader = command.ExecuteReader()) {
        while (reader.Read()) {

          Reader? _object = new Reader();
          _object.Id = Convert.ToInt32(reader["Id"]);
          _object.FirstName = reader["FirstName"].ToString();
          _object.LastName = reader["LastName"].ToString();
          _object.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
          _object.CityId = Convert.ToInt32(reader["CityId"]);
          _object.IIN = reader["IIN"].ToString();

          books.Add(_object);
        }
      }
    }
    return books;
  }
}