using Filmoon.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel mainWindowViewModel)
    {
        DataContext = mainWindowViewModel;

        InitializeComponent();
    }
}
