using Spectre.Console;

namespace Flashcards.Api.Views;

public static class UserInterface
{
    public static void Run()
    {
        while (true)
        {
            AnsiConsole.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select [bold]Operation[/]:")
                    .AddChoices("Manage Stacks", "Manage Flashcards", "Study", "View Study Session History", "Exit"));


            switch (choice)
            {
                case "Manage Stacks":
                    StackUi.Run();
                    break;
            }
        }
    }
}