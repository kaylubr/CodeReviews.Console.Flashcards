using Dapper;
using Microsoft.Data.SqlClient;
using Flashcards.Api.Configs;
using Flashcards.Api.Models;

namespace Flashcards.Api.Service;

internal static class StackService
{
    private static readonly string _connectionString = DatabaseConfigs.ConnectionString;

    internal static void Create(string name)
    {
        using var connection = new SqlConnection(_connectionString);

        var sqlQuery = "INSERT INTO flashcard_db (Name) VALUES (@name)";
        connection.Execute(sqlQuery, new { name });
    }

    internal static List<Stack> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);

        var sqlQuery = "SELECT * FROM stacks";
        return connection.Query<Stack>(sqlQuery).ToList();
    }
}