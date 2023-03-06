using System.Collections.Generic;

namespace HotelAppLibrary.Databases;

public interface ISqlDataAccess
{
    List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName, DataAccessOptions? options);

    void SaveData<T>(string sql, T parameters, string connectionStringName, DataAccessOptions? options);
}