using System;
using System.Windows.Input;

namespace Filmoon.Commands;

public class GoToPageCommand : ICommand
{
    public GoToPageCommand(Action action)
    {
        Action = action;
    }

    private Action Action { get; }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        throw new NotImplementedException();
    }
}
