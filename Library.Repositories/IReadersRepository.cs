using Library.Entities;
namespace Library.Repositories;

public interface IReadersRepository {
  int GetReaderCount();
  List<Reader> GetReaderCity(int cityId);
  List<Reader> GetReaderIIN(string iin);
  int ReadersCount(int cityid);
}

public class LinqToReadersRepository : IReadersRepository {
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

}