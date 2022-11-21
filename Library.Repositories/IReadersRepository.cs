using Library.Entities;
using System.Data.SqlClient;

namespace Library.Repositories;

public interface IReadersRepository {
  int GetReaderCount();
  List<Reader> GetReaderCity(int cityId);
  List<Reader> GetReaderIIN(string iin);
  int ReadersCount(int cityid);
  Reader GetReaderById(int id);
  void DeleteReaderById(int id);
}

public class LinqToReadersRepository : IReadersRepository {
  string connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
  public int GetReaderCount() {
    return DataStorage.GetReaders().Count;
  }
  public List<Reader> GetReaderCity(int cityId) {
    return DataStorage.GetReaders().Where(reader => reader.CityId == cityId).ToList();
  }
  public List<Reader> GetReaderIIN(string iin) {
    return DataStorage.GetReaders().Where(reader => reader.IIN == iin).ToList();
  }
  public int ReadersCount(int cityid) {
    return DataStorage.GetReaders().Where(reader => reader.CityId == cityid).Count();
  }
  public Reader GetReaderById(int id) {
    return DataStorage.GetReaders().First(reader => reader.Id == id);
  }
  public void DeleteReaderById(int id) {
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand("DELETE FROM Readers WHERE Id = '" + id + "'", conn)) {
      conn.Open();
      command.ExecuteNonQuery();
    }
  }

}
