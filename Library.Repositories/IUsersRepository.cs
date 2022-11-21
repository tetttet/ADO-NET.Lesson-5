using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories {
  public interface IUsersRepository {
    User getById(int _id);
    List<User> getAll();
    List<User> findByLastNames(string lastName);
    User findByLastName(string lastName);
    List<User> findByFirstNames(string firstName);
    List<User> findByNoneActive();
    List<User> findByActiveUser();
    List<User> sortByLastName();
    List<User> sortByDateTime();
    List<User> sortByLastNameBirthDate();
  }

  public class LinqToObjectUsersRepository : IUsersRepository {

    public User getById(int _id) {
      return DataStorage.GetUsers().First(user => user.Id == _id);
    }
    public List<User> getAll() {
      return DataStorage.GetUsers();
    }
    public List<User> findByLastNames(string lastName) {
      return DataStorage.GetUsers().Where(user => user.LastName == lastName).ToList();
    }
    public User findByLastName(string lastName) {
      return DataStorage.GetUsers().First(user => user.LastName == lastName);
    }
    public List<User> findByFirstNames(string firstName) {
      return DataStorage.GetUsers().Where(user => user.FirstName == firstName).ToList();
    }
    public User findByFirstName(string firstName) {
      return DataStorage.GetUsers().First(user => user.FirstName == firstName);
    }
    public List<User> findByNoneActive() {
      return DataStorage.GetUsers().Where(user => user.IsActive == false).ToList();
    }
    public List<User> findByActiveUser() {
      return DataStorage.GetUsers().Where(user => user.IsActive == true && Convert.ToInt32(DateTime.Now - user.BirthDate) > 20).ToList();
    }
    public List<User> sortByLastName() {
      return DataStorage.GetUsers().OrderBy(p => p.LastName).ToList();
    }
    public List<User> sortByDateTime() {
      return DataStorage.GetUsers().OrderBy(p => p.BirthDate).ToList();
    }
    public List<User> sortByLastNameBirthDate() {
      return DataStorage.GetUsers().OrderBy(p => p.LastName).ThenBy(p => p.BirthDate).ToList(); ;
    }
    
  }
}
