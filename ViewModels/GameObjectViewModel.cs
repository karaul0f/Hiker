using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using Hiker_Editor.Models;

namespace Hiker_Editor.ViewModels
{
    class GameObjectViewModel
    {
        GameObject _gameObject;
        Sprite[] _sprites;
        public GameObjectViewModel(ref GameObject gameObject, ref Sprite[] sprites)
        {
            _gameObject = gameObject;
            _sprites = sprites;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public GameObject CurrentGameObject
        {
            private set { }
            get { return _gameObject; }
        }

        public Sprite[] Sprites
        {
            private set { }
            get { return _sprites; }
        }

    }
}
