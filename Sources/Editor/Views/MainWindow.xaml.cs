using System.Windows;
using System.Windows.Controls;
using HikerEditor.Models.Interfaces;
using HikerEditor.ViewModels;


namespace HikerEditor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EntitiesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EntitiesList.SelectedItems.Count > 0)
            {
                (DataContext as MainWindowViewModel).SelectedEntity = (IEntity) EntitiesList.SelectedItems[0];
            }
        }
    }
}
