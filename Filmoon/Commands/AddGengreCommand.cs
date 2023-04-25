using System;
using System.Windows.Input;

namespace Filmoon.Commands;

public class AddGenreCommand : ICommand
{
    public AddGenreCommand(Action<object> action)
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
        action.Invoke(parameter);
    }
}
