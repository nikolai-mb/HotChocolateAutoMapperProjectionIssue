using Microsoft.Data.Sqlite;

namespace HotChocolateAutoMapperProjectionIssue;

public static class SqliteConnectionProvider
{
    private static SqliteConnection? _sqliteConnection;

    public static SqliteConnection GetSqliteConnection()
    {
        if (_sqliteConnection is null)
        {
            _sqliteConnection = new SqliteConnection("DataSource=:memory:");
            _sqliteConnection.Open();
        }

        return _sqliteConnection;
    }
}