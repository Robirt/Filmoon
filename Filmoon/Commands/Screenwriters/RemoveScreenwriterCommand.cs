﻿using System;
using System.Windows.Input;

namespace Filmoon.Commands.Screenwriters;

public class RemoveScreenwriterCommand : ICommand
{
    public RemoveScreenwriterCommand(Action<object> action)
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
