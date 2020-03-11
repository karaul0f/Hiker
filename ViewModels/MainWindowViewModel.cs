using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Hiker_Editor.Models;

namespace Hiker_Editor.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProjectItem> StructureProject { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public MainWindowViewModel()
        {
            StructureProject = new ObservableCollection<ProjectItem>
            {
                new ProjectItem { Name="Sprites", ItemsOperation = new ObservableCollection<MenuItem> { new MenuItem { Header = "Add" } } },
                new ProjectItem { Name="Scripts" },
                new ProjectItem { Name="Objects" },
                new ProjectItem { Name="Rooms" }
            };
        }
    }
}
