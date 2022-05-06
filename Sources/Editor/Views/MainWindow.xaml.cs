using System.Windows;
using System.Windows.Controls;
using AdonisUI.Controls;
using HikerEditor.Models.Interfaces;
using HikerEditor.ViewModels;


namespace HikerEditor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : AdonisWindow
    {
        private MainWindowViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = DataContext as MainWindowViewModel;
        }
    }
}
