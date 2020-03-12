using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Hiker_Editor.Models
{
    public class StructureProject : INotifyPropertyChanged
    {
        public ObservableCollection<ProjectItem> ProjectItems { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public StructureProject()
        {
            ProjectItems = new ObservableCollection<ProjectItem>
            {
                new ProjectItem { Name="Sprites", ItemsOperation = new ObservableCollection<MenuItem> { new MenuItem { Header = "Add" } } },
                new ProjectItem { Name="Scripts" },
                new ProjectItem { Name="Objects" },
                new ProjectItem { Name="Rooms" }
            };
        }

    }
}
