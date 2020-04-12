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
    public class ProjectItem : INotifyPropertyChanged
    {
        private string _name = "";
        private string _imagePath = "";
        public ObservableCollection<MenuItem> ItemsOperation { get; set; }
        public ObservableCollection<ProjectItem> Items { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ProjectItem()
        {
            ItemsOperation = new ObservableCollection<MenuItem> { new MenuItem { Header = "Create", IsEnabled = false }, new MenuItem { Header = "Edit", IsEnabled = false }, new MenuItem { Header = "Delete", IsEnabled = false } };
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }
        
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if (value == _imagePath) return;
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<ProjectItem> InitializationStructureProject()
        {
            ObservableCollection<ProjectItem> _structureProject = new ObservableCollection<ProjectItem>
            {
                new ProjectItemBuilder().SetType(ProjectItemType.Folder).SetName("Sprites"),
                new ProjectItemBuilder().SetType(ProjectItemType.Folder).SetName("Scripts"),
                new ProjectItemBuilder().SetType(ProjectItemType.Folder).SetName("Objects"),
                new ProjectItemBuilder().SetType(ProjectItemType.Folder).SetName("Rooms")
            };
            return _structureProject;
        }
    }
}
