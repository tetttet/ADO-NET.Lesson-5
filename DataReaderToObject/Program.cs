using System.Data.SqlClient;
using System.Data.SqlTypes;
using DataReaderToObject.Entities;

public static class Program
{
    public static void Main(string[] args)
    {
        List<Author> authors = GetAuthors();
        foreach (Author author in authors)
        {
            Console.WriteLine($"{author.Id} | {author.FirstName} | {author.LastName} |  {author.Comment}");
        }

        Console.ReadLine();
    }

    public static List<Author> GetAuthors()
    {
        List<Author> result = new List<Author>();
        using (SqlConnection sqlConnection = GetSqlConnection())
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM AUTHORS";
        
            sqlConnection.Open();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Author author = new Author();
                    author.Id = GetInt(reader, nameof(Author.Id));
                    author.FirstName = GetString(reader,nameof(Author.FirstName));
                    author.LastName = GetString(reader,nameof(Author.LastName));
                    author.Comment = GetString(reader, nameof(Author.Comment));
                    result.Add(author);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Получить тип данный int
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static int GetInt(SqlDataReader reader, string propertyName)
    {
        SqlInt32 sqlInt32 = reader.GetSqlInt32(reader.GetOrdinal(propertyName));
        
        if (sqlInt32.IsNull)
        {
            throw new Exception("Expected type Int32. Value = SqlInt32.Null");
        }

        return sqlInt32.Value;
    }

    /// <summary>
    /// Получить тип данный string
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    private static string GetString(SqlDataReader reader, string propertyName)
    {
        var sqlString = reader.GetSqlString(reader.GetOrdinal(propertyName));
        
        if (sqlString.IsNull)
        {
            return null;
        }

        return sqlString.Value;
    }


    /// <summary>
    /// Получить SqlConnection
    /// </summary>
    /// <returns></returns>
    private static SqlConnection GetSqlConnection()
    {
        return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Library; Integrated Security=SSPI;");
    }
}