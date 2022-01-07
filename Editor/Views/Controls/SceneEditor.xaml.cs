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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HikerEditor.Models.Editor;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Views.Controls
{
    /// <summary>
    /// Interaction logic for SceneEditor.xaml
    /// </summary>
    public partial class SceneEditor : UserControl
    {
        public SceneEditor()
        {
            InitializeComponent();
            Editor.EditorInstance.SceneEditor.OnEntityAdded += SceneEditorOnOnEntityAdded;
        }

        private void SceneEditorOnOnEntityAdded(VisualEntity visualEntity)
        {
            var image = new Image();
            image.Stretch = Stretch.Fill;
            image.Source = visualEntity.Image;
            Scene.Children.Add(image);
        }

        ~SceneEditor()
        {
            Editor.EditorInstance.SceneEditor.OnEntityAdded -= SceneEditorOnOnEntityAdded;
        }
    }
}
