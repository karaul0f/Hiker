using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Hiker_Editor.Models;
using Hiker_Editor.Views;

namespace Hiker_Editor.ViewModels
{
    public class GameObjectViewModel
    {
        RelayCommand _createEvent, _createAction;
        GameObject _gameObject;
        ObservableCollection<Sprite> _sprites;
        public GameObjectViewModel(ref GameObject gameObject, ref ObservableCollection<Sprite> sprites)
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

        public ObservableCollection<Sprite> Sprites
        {
            private set { }
            get { return _sprites; }
        }

        public RelayCommand CreateEvent
        {
            get
            {
                return _createEvent ??
                  (_createEvent = new RelayCommand(obj =>
                  {
                      CreateEventWindow createEventWindow = new CreateEventWindow();
                      createEventWindow.ShowDialog();
                  }));
            }
        }

        public RelayCommand CreateAction
        {
            get
            {
                return _createAction ??
                  (_createAction = new RelayCommand(obj =>
                  {
                      CreateActionWindow createActionWindow = new CreateActionWindow();
                      createActionWindow.ShowDialog();
                  }));
            }
        }

    }
}
