using Library.Entities;

namespace Library.Repositories;

public interface IAuthorsRepository
{
    public List<Author> GetAll();

    public List<Author> GetByFirstName(string firstName);

    public List<Author> GetByFirstNameAndLastName(string firstName, string lastName);

    int GetGroupCountByLastName(string lastName);
}

public class LinqToObjectAuthorsRepository : IAuthorsRepository {
  public List<Author> GetAll() {
    List<Author> authors = DataStorage.GetAuthors();

    IEnumerable<Author> result = from author in authors
                                 select author;
    return result.ToList();
  }

  public List<Author> GetByFirstName(string firstName) {
    List<Author> authors = DataStorage.GetAuthors();

    IEnumerable<Author> result = from author in authors
                                 where author.FirstName == firstName
                                 select author;
    return result.ToList();
  }

  public List<Author> GetByFirstNameAndLastName(string firstName, string lastName) {
    List<Author> authors = DataStorage.GetAuthors();

    IEnumerable<Author> result = from author in authors
                                 where author.FirstName == firstName && author.LastName == lastName
                                 select author;
    return result.ToList();
  }

  public int GetGroupCountByLastName(string lastName) {
    List<Author> authors = DataStorage.GetAuthors();

    var groupByLastName = from author in authors
                          group author by author.LastName into g
                          select new { GroupName = g.Key, Count = g.Count() };

    var groupCountByLastName = from gr in groupByLastName
                               where gr.GroupName == lastName
                               select gr.Count;

    return groupCountByLastName.ElementAt(0);
  }
}