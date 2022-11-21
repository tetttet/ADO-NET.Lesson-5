using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace AbstractExample;

public class Factory
{
    private readonly DbType dbType;
    private readonly string connectionString;

    public Factory(DbType dbType, string connectionString)
    {
        this.dbType = dbType;
        this.connectionString = connectionString;
    }

    /// <summary>
    /// Получить подключение в зависимости от типа
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public DbConnection GetDbConnection()
    {
        switch (dbType)
        {
            case DbType.Sql:
                return new SqlConnection(connectionString);
            case DbType.OleDb:
                return new OleDbConnection(connectionString);
            default:
                throw new NotImplementedException($"Implementation not found for type {typeof(DbType)} = {dbType}");
        }
    }
    
    /// <summary>
    /// Получить команду в зависимости от типа
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public DbCommand GetDbCommand()
    {
        switch (dbType)
        {
            case DbType.Sql:
                return new SqlCommand();
            case DbType.OleDb:
                return new OleDbCommand();
            default:
                throw new NotImplementedException($"Implementation not found for type {typeof(DbType)} = {dbType}");
        }
    }
    
    /// <summary>
    /// Получить CommandBuilder в зависимости от типа
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public DbCommandBuilder GetDbCommandBuilder()
    {
        switch (dbType)
        {
            case DbType.Sql:
                return new SqlCommandBuilder();
            case DbType.OleDb:
                return new OleDbCommandBuilder();
            default:
                throw new NotImplementedException($"Implementation not found for type {typeof(DbType)} = {dbType}");
        }
    }
}