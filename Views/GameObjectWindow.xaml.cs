using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Hiker_Editor.Models;
using Hiker_Editor.ViewModels;

namespace Hiker_Editor.Views
{
    /// <summary>
    /// Логика взаимодействия для ObjectWindow.xaml
    /// </summary>
    public partial class GameObjectWindow : Window
    {
        public GameObjectWindow(ref GameObject gameObject, ref Sprite[] sprites)
        {
            InitializeComponent();
            DataContext = new GameObjectViewModel(ref gameObject, ref sprites);
        }
    }
}
