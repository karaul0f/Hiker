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
    class ProjectItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _name;
        public string Name
        { get { return _name; }
          set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        
        }
        public List<MenuItem> MenuItems { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }
    }
}
