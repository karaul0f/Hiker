using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Hiker_Editor.Models;

namespace Hiker_Editor.ViewModels
{
    public class SpriteViewModel : INotifyPropertyChanged
    {
        Sprite _sprite;
        RelayCommand _loadSprite;
        public SpriteViewModel(ref Sprite sprite)
        {
            _sprite = sprite;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Sprite CurrentSprite
        {
            private set { }
            get { return _sprite; }
        }

        public RelayCommand LoadSprite
        {
            get
            {
                return _loadSprite ??
                  (_loadSprite = new RelayCommand(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.ShowDialog();
                      CurrentSprite.ImagePath = openFileDialog.FileName;
                  }));
            }
        }
    }
}
