using Filmoon.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;

namespace Filmoon.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        Content = ServiceProvider.GetRequiredService<HomePage>();
    }

    private IServiceProvider ServiceProvider { get; }

    private Page content;
    public Page Content
    {
        get { return content; }
        set { SetProperty(ref content, value); }
    }
}
