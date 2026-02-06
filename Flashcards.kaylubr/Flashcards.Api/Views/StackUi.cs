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
                ViewAllStacksOperation();
                break;
            case "Create A Stack":
                CreateStackOperation();
                break;
            case "Edit Stack Name":
                break;
            case "Delete Stack":
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
                .Title("[yellow bold]Manage Stacks[/]")
                .AddChoices("View All Stacks", "Create A Stack", "Edit Stack Name", "Delete Stack", "Go Back Menu"));
    }

    private static void ViewAllStacksOperation()
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

    private static void CreateStackOperation()
    {
        bool success = false;
        while (!success)
        {
            string newStackName = AnsiConsole.Ask<string>("What would you like to name the stack? (Duplicates are invalid): ");

            if (StackController.CreateStack(newStackName))
            {
                AnsiConsole.MarkupLine("\n[green]Successfully created a new stack![/]");
                AnsiConsole.Markup("Press any key to continue..");
                Console.ReadKey();
                return;
            }
            else
                AnsiConsole.MarkupLine("\n[red]Invalid! Name already exists.[/]\n");
        }

    }
}