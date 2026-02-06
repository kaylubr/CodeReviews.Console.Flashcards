using Dapper;
using Microsoft.Data.SqlClient;
using Flashcards.Api.Configs;
using Flashcards.Api.Models;

namespace Flashcards.Api.Service;

internal static class StackService
{
    private static readonly string _connectionString = DatabaseConfigs.ConnectionString;

    internal static bool Create(string name)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);

            var sqlQuery = "INSERT INTO stacks (Name) VALUES (@name)";
            connection.Execute(sqlQuery, new { name });
            return true;
        }
        catch (SqlException)
        {
            return false;
        }
    }

    internal static List<Stack> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);

        var sqlQuery = "SELECT * FROM stacks";
        return connection.Query<Stack>(sqlQuery).ToList();
    }
}