using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        public static readonly DependencyProperty EntitiesProperty;

        private Dictionary<IEntity, TexturedBox3D> _visualEntities;
        private IEntity _selectedEntity;

        private ObservableCollection<IEntity> _entities;

        static SceneEditor()
        {
            EntitiesProperty = DependencyProperty.Register(
                "Entities",
                typeof(ObservableCollection<IEntity>),
                typeof(SceneEditor),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    OnItemSourceChanged));
        }

        public SceneEditor()
        {

            InitializeComponent();
            _visualEntities = new Dictionary<IEntity, TexturedBox3D>();
            Editor.EditorInstance.SceneEditor.OnEntityAdded += SceneEditorOnOnEntityAdded;
            Editor.EditorInstance.SceneEditor.OnSelectionChanged += SceneEditorOnOnSelectionChanged;
            _selectedEntity = Editor.EditorInstance.SceneEditor.SelectedEntity;
        }

        public ObservableCollection<IEntity> Entities
        {
            get => (ObservableCollection<IEntity>) GetValue(EntitiesProperty);
            set => SetValue(EntitiesProperty, value);
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                    Delete((IEntity)item);
            }

            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                    Add((IEntity)item);
            }
        }

        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SceneEditor control = (SceneEditor) d;
            var entitiesCollection = (ObservableCollection<IEntity>) e.NewValue;
            entitiesCollection.CollectionChanged += control.OnCollectionChanged;
        }

        public void Add(IEntity entity)
        {
            VisualComponent vc = (VisualComponent) entity.Components[0];
            _visualEntities[entity] = new TexturedBox3D(VisualEntities, vc.WorldPosition.X, -vc.WorldPosition.Y, 0, vc.PathToImage, new System.Windows.Size(1, 1));
        }

        public void Delete(IEntity entity)
        {
            
            _visualEntities.Remove(entity);
        }


        private void SceneEditorOnOnSelectionChanged(IEntity visualEntity)
        {
            //_visualEntities[_selectedEntity].Opacity = 1.0f;
            //_visualEntities[Editor.EditorInstance.SceneEditor.SelectedEntity].Opacity = 0.5f;

        }

        private void SceneEditorOnOnEntityAdded(IEntity visualEntity)
        {
            //Add(visualEntity);
        }

        ~SceneEditor()
        {
            Editor.EditorInstance.SceneEditor.OnEntityAdded -= SceneEditorOnOnEntityAdded;
            Editor.EditorInstance.SceneEditor.OnSelectionChanged -= SceneEditorOnOnSelectionChanged;
        }

    }
}
