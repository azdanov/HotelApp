using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HotelAppLibrary.Databases;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public List<T> LoadData<T, TU>(string sql, TU parameters, string connectionStringName, DataAccessOptions? options)
    {
        var connectionString = _config.GetConnectionString(connectionStringName);
        using var connection = new SqlConnection(connectionString);
        var commandType = options is { IsStoredProcedure: true } ? CommandType.StoredProcedure : CommandType.Text;

        return connection.Query<T>(sql, parameters, commandType: commandType).ToList();
    }

    public void SaveData<T>(string sql, T parameters, string connectionStringName, DataAccessOptions? options)
    {
        var connectionString = _config.GetConnectionString(connectionStringName);
        using var connection = new SqlConnection(connectionString);
        var commandType = options is { IsStoredProcedure: true } ? CommandType.StoredProcedure : CommandType.Text;

        connection.Execute(sql, parameters, commandType: commandType);
    }
}