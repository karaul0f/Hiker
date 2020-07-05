using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using Hiker_Editor.Models;
using Hiker_Editor.Views;

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
