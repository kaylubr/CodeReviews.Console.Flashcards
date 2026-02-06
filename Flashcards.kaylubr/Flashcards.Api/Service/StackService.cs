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
            connection.QuerySingle<Stack>(sqlQuery, new { id });
        }
        catch
        {
            return false;
        }

        return true;
    }

    internal static bool UpdateNameById(int id, string name)
    {
        using var connection = new SqlConnection(_connectionString);

        try
        {
            var sqlQuery = "UPDATE stacks SET Name = @name WHERE Id = @id";
            connection.Execute(sqlQuery, new { name, id });
        }
        catch
        {
            return false;
        }

        return true;
    }

    internal static bool DeleteById(int id)
    {
        using var connection = new SqlConnection(_connectionString);

        try
        {
            var sqlQuery = "DELETE FROM stacks WHERE Id = @id";

            if (connection.Execute(sqlQuery, new { id }) == 0)
                return false;
        }
        catch
        {
            return false;
        }

        return true;
    }

}