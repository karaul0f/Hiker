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
using System.Windows.Media.Media3D;
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
        private Dictionary<VisualEntity, TexturedBox3D> _visualEntities;
        private VisualEntity _selectedEntity;

        public SceneEditor()
        {
            InitializeComponent();
            _visualEntities = new Dictionary<VisualEntity, TexturedBox3D>();
            Editor.EditorInstance.SceneEditor.OnEntityAdded += SceneEditorOnOnEntityAdded;
            Editor.EditorInstance.SceneEditor.OnSelectionChanged += SceneEditorOnOnSelectionChanged;
            _selectedEntity = Editor.EditorInstance.SceneEditor.SelectedEntity;
        }

        private void SceneEditorOnOnSelectionChanged(VisualEntity visualEntity)
        {
            _visualEntities[_selectedEntity].Opacity = 1.0f;
            _visualEntities[Editor.EditorInstance.SceneEditor.SelectedEntity].Opacity = 0.5f;

        }

        private void SceneEditorOnOnEntityAdded(VisualEntity visualEntity)
        {
            _visualEntities[visualEntity] = new TexturedBox3D(VisualEntities, visualEntity.WorldPosition.X, -visualEntity.WorldPosition.Y, 0, visualEntity.Image, new System.Windows.Size(1, 1));
        }

        ~SceneEditor()
        {
            Editor.EditorInstance.SceneEditor.OnEntityAdded -= SceneEditorOnOnEntityAdded;
            Editor.EditorInstance.SceneEditor.OnSelectionChanged -= SceneEditorOnOnSelectionChanged;
        }
    }
}
