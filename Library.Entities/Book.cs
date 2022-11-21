//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Library.Entities {
  public class Book {
    public int AuthorId { get; set; }
    public int BookId { get; set; }
    public string Name { get; set; }
    public int? PageCount { get; set; }
    public int? Publishing { get; set; }
    public int TypeId { get; set; }
    public string? Comment { get; set; }
    public int GenreId { get; set; }
  }
}
