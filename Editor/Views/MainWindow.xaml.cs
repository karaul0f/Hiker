using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
