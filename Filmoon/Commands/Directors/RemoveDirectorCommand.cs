using System;
using System.Windows.Input;

namespace Filmoon.Commands.Directors;

public class RemoveDirectorCommand : ICommand
{
    public RemoveDirectorCommand(Action<object> action)
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
