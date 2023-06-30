using System.Windows;
using AlgoritmoGenetico.ViewModels;

namespace AlgoritmoGenetico
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(Canvas);
        }
    }
}
