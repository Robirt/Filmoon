using Filmoon.ViewModels;
using System.Windows;

namespace Filmoon.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel mainWindowViewModel)
    {
        DataContext = mainWindowViewModel;

        InitializeComponent();
    }
}
