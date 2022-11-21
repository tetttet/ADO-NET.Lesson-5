// See https://aka.ms/new-console-template for more information

using System.Data.Common;

namespace AbstractExample;

public static class Program
{
    public static void Main(string[] args)
    {
        Factory factory = new Factory(DbType.Sql, @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Library; Integrated Security=SSPI;");
        Get(factory);
    }

    /// <summary>
    /// Метод получения данных из 
    /// </summary>
    /// <param name="factory"></param>
    private static void Get(Factory factory)
    {
        DbConnection dbConnection = factory.GetDbConnection();

        DbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT * FROM AUTHORS";

        dbConnection.Open();
        DbTransaction dbTransaction = dbConnection.BeginTransaction();
        dbCommand.Transaction = dbTransaction;

        try
        {
            using (DbDataReader dataReader = dbCommand.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    Console.WriteLine($"Value = {dataReader[0]}");
                }
            }

            dbTransaction.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            dbTransaction.Rollback();
        }
        finally
        {
            dbConnection.Close();
        }
    }
}