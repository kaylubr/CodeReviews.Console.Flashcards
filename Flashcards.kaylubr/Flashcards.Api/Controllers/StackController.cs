using Flashcards.Api.Service;
using Flashcards.Api.Configs;

namespace Flashcards.Api.Controllers;

public static class StackController
{
    public static void CreateStack(string name)
    {
        string cleanedName = Helper.Capitalize(name.Trim());
        StackService.Create(cleanedName);
    }
}