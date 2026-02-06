using Flashcards.Api.Configs;
using Flashcards.Api.Models;
using Flashcards.Api.Service;

namespace Flashcards.Api.Controllers;

public static class StackController
{
    public static bool CreateStack(string name)
    {
        string cleanedName = Helper.Capitalize(name.Trim());
        return StackService.Create(cleanedName);
    }

    public static List<Stack> GetAll()
    {
        return StackService.GetAll();
    }

    public static bool GetById(int id)
    {
        return StackService.GetById(id);
    }

    public static bool UpdateNameById(int id, string name)
    {
        string cleanedName = Helper.Capitalize(name.Trim());
        return StackService.UpdateNameById(id, cleanedName);
    }

    public static bool DeleteById(int id)
    {
        return StackService.DeleteById(id);
    }


}