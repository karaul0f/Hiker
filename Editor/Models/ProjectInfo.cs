using System.ComponentModel;
using System.Runtime.CompilerServices;

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
