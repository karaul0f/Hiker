using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Hiker_Editor.ViewModels;


namespace Hiker_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        
        ObservableCollection<Node> nodes;
        public MainWindow()
        {
            InitializeComponent();

            

            nodes = new ObservableCollection<Node>
            {
                new Node { Name="Sprites" },
                new Node { Name="Scripts" },
                new Node { Name="Objects" },
                new Node { Name="Rooms" }
              };

            StructureProject.ItemsSource = nodes;
        }

        private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
    public class Node
    {
        public Node()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem() { Header = "Add"},
                new MenuItem() { Header = "Edit"},
                new MenuItem() { Header = "Delete"},
            };
        }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }
    }
}
