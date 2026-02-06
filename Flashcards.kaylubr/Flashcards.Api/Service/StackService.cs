using Dapper;
using Flashcards.Api.Configs;
using Microsoft.Data.SqlClient;

namespace Flashcards.Api.Service;

public static class StackService
{
    private static readonly string _connectionString = DatabaseConfigs.ConnectionString;

    public static void Create(string name)
    {
        using var connection = new SqlConnection(_connectionString);

        var sqlQuery = "INSERT INTO flashcard_db (Name) VALUES (@name)";
        connection.Execute(sqlQuery, new { name });
    }
}