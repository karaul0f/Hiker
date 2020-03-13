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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private string _name = "";
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
        private string _imagePath = "";
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
        public ObservableCollection<MenuItem> ItemsOperation { get; set; }
        public ObservableCollection<ProjectItem> Items { get; set; }
        public static ObservableCollection<ProjectItem> InitializationStructureProject()
        {
            ObservableCollection<ProjectItem> structureProject = new ObservableCollection<ProjectItem>
            {
                new ProjectItem { 
                    Items = new ObservableCollection<ProjectItem>(), 
                    Name="Sprites", 
                    ImagePath = "/Images/folder.png", 
                    ItemsOperation = new ObservableCollection<MenuItem> { new MenuItem { Header = "Add sprite" } } 
                },
                new ProjectItem { 
                    Items = new ObservableCollection<ProjectItem>(), 
                    Name="Scripts", 
                    ImagePath = "/Images/folder.png", 
                    ItemsOperation = new ObservableCollection<MenuItem> { new MenuItem { Header = "Add script" } } 
                },
                new ProjectItem {
                    Items = new ObservableCollection<ProjectItem>(),
                    Name="Objects", 
                    ImagePath = "/Images/folder.png", 
                    ItemsOperation = new ObservableCollection<MenuItem> { new MenuItem { Header = "Add object" } } 
                },
                new ProjectItem { 
                    Items = new ObservableCollection<ProjectItem>(), 
                    Name="Rooms", 
                    ImagePath = "/Images/folder.png", 
                    ItemsOperation = new ObservableCollection<MenuItem> { new MenuItem { Header = "Add room" } } 
                }
            };
            return structureProject;
        }
    }
}
