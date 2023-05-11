using System;
using System.Windows.Input;

namespace Filmoon.Commands.Users;

public class SignOutCommand : ICommand
{
    public SignOutCommand(Action action)
    {
        this.action = action;
    }

    public event EventHandler? CanExecuteChanged;

    private Action action;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        action.Invoke();
    }
}
