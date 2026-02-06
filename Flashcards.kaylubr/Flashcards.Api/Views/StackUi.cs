using Spectre.Console;
using Flashcards.Api.Controllers;
using Flashcards.Api.Models;

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
                EditStackOperation();
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
        var panel = new Panel("[bold]Manage Stacks[/]");
        AnsiConsole.Write(panel);
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices("View All Stacks", "Create A Stack", "Edit Stack Name", "Delete Stack", "Go Back Menu"));
    }

    private static void ViewAllStacksOperation()
    {
        RenderStacksInTable();
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

    private static void EditStackOperation()
    {
        RenderStacksInTable(withId: true);

        int id;
        while (true)
        {
            id = AnsiConsole.Ask<int>("\nEnter Stack ID to Edit: ");

            bool stackExists = StackController.GetById(id);

            if (stackExists)
                break;

            AnsiConsole.MarkupLine("\n[red]Invalid! Stack with that ID doesn't exists.[/]\n");
        }

        AnsiConsole.Clear();

        while (true)
        {
            string newStackName = AnsiConsole.Ask<string>("\nEnter New Stack Name: ");
            if (StackController.UpdateNameById(id, newStackName))
            {
                AnsiConsole.MarkupLine("\n[green]Successfully edited stack name![/]");
                AnsiConsole.Markup("Press any key to continue..");
                Console.ReadKey();
                return;
            }
            else
                AnsiConsole.MarkupLine("\n[red]Invalid! Name already exists.[/]\n");
        }

    }

    private static void RenderStacksInTable(bool withId = false)
    {
        var stackList = StackController.GetAll();

        AnsiConsole.Clear();

        if (stackList.Count >= 1)
        {
            var table = new Table()
                .Border(TableBorder.Heavy);

            if (withId)
                table.AddColumn("[yellow bold]ID[/]");

            table.AddColumn("[yellow bold]Stack[/]");

            foreach (var stack in stackList)
            {
                if (withId)
                    table.AddRow(stack.Id.ToString(), stack.Name);
                else
                    table.AddRow(stack.Name);
            }

            AnsiConsole.Write(table);
        }
        else
            AnsiConsole.Write("No stacks yet.");
    }
}