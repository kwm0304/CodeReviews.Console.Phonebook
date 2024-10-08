using Spectre.Console;

namespace Phonebook.kwm0304.Views;

public class Container<T>(string title, List<T> choices, T cancelMethod) where T : notnull
{
  public string Title { get; set; } = title;
  public List<T> Choices { get; set; } = choices;

  public T? Show()
  {
    if (Choices.Count < 1)
    {
      AnsiConsole.WriteLine("Nothing to display");
      return default;
    }
    return AnsiConsole.Prompt(
        new SelectionPrompt<T>()
            .Title(Title)
            .AddChoices(Choices)
            .AddChoices(cancelMethod)
    );
  }
}