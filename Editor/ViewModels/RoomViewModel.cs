using System.ComponentModel;
using System.Runtime.CompilerServices;
using Hiker_Editor.Models;

namespace Hiker_Editor.ViewModels
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        Room _room;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public RoomViewModel(ref Room room)
        {
            _room = room;
        }
    }
}
