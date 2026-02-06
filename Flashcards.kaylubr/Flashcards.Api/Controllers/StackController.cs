using Flashcards.Api.Configs;
using Flashcards.Api.Models;
using Flashcards.Api.Service;

namespace Flashcards.Api.Controllers;

public static class StackController
{
    public static void CreateStack(string name)
    {
        string cleanedName = Helper.Capitalize(name.Trim());
        StackService.Create(cleanedName);
    }

    public static List<Stack> GetAll()
    {
        return StackService.GetAll();
    }
}