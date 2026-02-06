using Spectre.Console;
using Flashcards.Api.Controllers;

namespace Flashcards.Api.Views;

public static class StackUi
{
    public static void Run()
    {
        var choice = OperationPrompt();
        switch (choice)
        {
            case "View All Stacks":
                ViewAllStacks();
                break;
            case "Create A Stack":
                ViewAllStacks();
                break;
            case "Edit Stack Name":
                ViewAllStacks();
                break;
            case "Delete Stack":
                ViewAllStacks();
                break;
            case "Go Back Menu":
                return;
        }

    }

    private static string OperationPrompt()
    {
        AnsiConsole.Clear();
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select [bold]Operation[/]:")
                .AddChoices("View All Stacks", "Create A Stack", "Edit Stack Name", "Delete Stack", "Go Back Menu"));
    }

    private static void ViewAllStacks()
    {
        var stackList = StackController.GetAll();

        if (stackList.Count >= 1)
        {
            var table = new Table()
                .Border(TableBorder.Heavy);

            table.AddColumn("[yellow bold]Stack[/]");

            foreach (var stack in stackList)
                table.AddRow(stack.Name);

            AnsiConsole.Write(table);
        }
        else
            AnsiConsole.Write("No stacks yet.");

        AnsiConsole.Write("\nPress any key to continue...");
        Console.ReadKey();
    }
}