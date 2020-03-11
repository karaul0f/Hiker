using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace Hiker_Editor.Models
{
    class ProjectItems : BindableBase
    {
        private string _name;
        public string Name
        { 
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private readonly ObservableCollection<ProjectItems> _myValues = new ObservableCollection<ProjectItems>();
        public readonly ReadOnlyObservableCollection<ProjectItems> MyPublicValues;
        public ProjectItems()
        {
            MyPublicValues = new ReadOnlyObservableCollection<ProjectItems>(_myValues);
            RaisePropertyChanged("Start");
        }
        public void AddElems()
        {
            _myValues.Add(new ProjectItems() { _name = "Sprites" });
            _myValues.Add(new ProjectItems() { _name = "Scripts" });
            _myValues.Add(new ProjectItems() { _name = "Objects" });
            _myValues.Add(new ProjectItems() { _name = "Rooms" });
        }
        //public List<MenuItem> MenuItems { get; set; }
        //public ObservableCollection<ProjectItems> _myValues { get; private set; }
    }
}
