using System;
using System.Windows.Input;

namespace Filmoon.Commands.Genres;

public class RemoveGenreCommand : ICommand
{
    public RemoveGenreCommand(Action<object> action)
    {
        this.action = action;
    }

    public event EventHandler? CanExecuteChanged;

    private Action<object> action;

    public bool CanExecute(object? parameter)
    {
        if (parameter is null) return false;

        return true;
    }

    public void Execute(object? parameter)
    {
        action.Invoke(parameter!);
    }
}
