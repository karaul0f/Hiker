///////////////////////////////////////////////////////////
// ProjectInfo.cs
//
// Автор: karaul0f
// Дата создания: 19.05.20
//
// Класс, который хранит информацию об игровом проекте.
///////////////////////////////////////////////////////////
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
    class ProjectInfo : INotifyPropertyChanged
    {
        private string _name;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Name
        {
            set 
            {
                _name = value;
                OnPropertyChanged();
            }
            get { return _name; }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
