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

    internal static bool GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);

        try
        {
            var sqlQuery = "SELECT * FROM stacks WHERE Id = @id";
            Stack stack = connection.QuerySingle<Stack>(sqlQuery, new { id });

            if (stack == null)
                return false;

            return true;
        }
        catch
        {
            return false;
        }

    }

    internal static bool UpdateNameById(int id, string name)
    {
        using var connection = new SqlConnection(_connectionString);

        try
        {
            var sqlQuery = "UPDATE stacks SET Name = @name WHERE Id = @id";
            connection.Execute(sqlQuery, new { name, id });
        }
        catch (SqlException)
        {
            return false;
        }

        return true;
    }
}