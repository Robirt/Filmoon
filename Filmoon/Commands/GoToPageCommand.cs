using System;
using System.Windows.Input;

namespace Filmoon.Commands;

public class GoToPageCommand : ICommand
{
    public GoToPageCommand(Action<string> action)
    {
        Action = action;
    }

    private Action<string> Action { get; }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        Action.Invoke((parameter as string)!);
    }
}
