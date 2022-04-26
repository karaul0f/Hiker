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

        private void EntitiesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EntitiesList.SelectedItems.Count > 0)
            {
                _vm.SelectedEntity = (IEntity) EntitiesList.SelectedItems[0];
            }
        }
    }
}
