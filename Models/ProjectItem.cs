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
        public ObservableCollection<MenuItem> ItemsOperation { get; set; }
        public ObservableCollection<ProjectItem> Items { get; set; }
    }
}
