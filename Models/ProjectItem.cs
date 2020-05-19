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
        protected string _name = "";
        protected string _imagePath = "";
        protected string _resourcePath = "";
        public ObservableCollection<MenuItem> ItemsOperation { get; set; }
        public ObservableCollection<ProjectItem> Items { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ProjectItem()
        {
            //ItemsOperation = new ObservableCollection<MenuItem> { new MenuItem { Header = "Create", IsEnabled = false }, new MenuItem { Header = "Edit", IsEnabled = false }, new MenuItem { Header = "Delete", IsEnabled = false } };
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

        public virtual bool IsEditable
        {
            get { return true; }
            set {}
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
                new Folder() { Name = "Sprites" },
                new Folder() { Name = "Scripts" },
                new Folder() { Name = "Objects" },
                new Folder() { Name = "Rooms" }
            };
            return _structureProject;
        }
    }
}
