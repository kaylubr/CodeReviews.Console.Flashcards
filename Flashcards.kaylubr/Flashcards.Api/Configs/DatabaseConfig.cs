using Microsoft.Extensions.Configuration;

namespace Flashcards.Api.Configs;

public static class DatabaseConfigs
{
    internal static string ConnectionString { get; private set; } = "";

    public static void Initialize()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        ConnectionString = builder.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");

        Console.WriteLine(ConnectionString);
    }
}