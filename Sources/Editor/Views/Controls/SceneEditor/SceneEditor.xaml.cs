using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.Editor;
using HikerEditor.Models.GameProject;
using HikerEditor.Utils;
using HikerEditor.Utils.Extensions;
using HikerEditor.ViewModels;

namespace HikerEditor.Views.Controls
{
    /// <summary>
	/// Interaction logic for SceneEditor.xaml
	/// </summary>
	public partial class SceneEditor : UserControl
    {
        private readonly SceneEditorViewModel _sceneEditorViewModel;

        private Dictionary<IEntity, GeometryModel3D> _visualEntities;

        public bool IsMouseDown { get; set; } = false;

        public static readonly DependencyProperty EntitiesProperty;

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
            _visualEntities = new Dictionary<IEntity, GeometryModel3D>();
            //Editor.EditorInstance.SceneEditor.OnSelectionChanged += OnSelectionChanged;

            _sceneEditorViewModel = DataContext as SceneEditorViewModel;
            Debug.Assert(_sceneEditorViewModel != null, nameof(_sceneEditorViewModel) + " != null");

            //_sceneEditorViewModel.PropertyChanged += OnPropertyChanged;
        }


        public ObservableCollection<IEntity> Entities
        {
            get => (ObservableCollection<IEntity>)GetValue(EntitiesProperty);
            set => SetValue(EntitiesProperty, value);
        }

        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
            SceneEditor control = (SceneEditor)d;
            var entitiesCollection = (ObservableCollection<IEntity>)e.NewValue;
            entitiesCollection.CollectionChanged += control.OnCollectionChanged;
        }

        public void Add(IEntity entity)
        {
            VisualComponent vc = (VisualComponent)entity.Components[0];
            GeometryModel3D texturedBox = TexturedBox3DBuilder.Create(vc.WorldPosition.X, -vc.WorldPosition.Y, 0, vc.PathToImage, new System.Windows.Size(1, 1));
            VisualEntities.Children.Add(texturedBox);
            _visualEntities[entity] = texturedBox;
        }

        public void Delete(IEntity entity)
        {
            _visualEntities.Remove(entity);
        }
        private void OnSelectionChanged(IEntity entity)
        {
            _sceneEditorViewModel.SelectedEntity = entity;
        }

        private void Grid_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = true;

            Point mousePosition = e.GetPosition(SceneViewport);
            PointHitTestParameters pointParams = new PointHitTestParameters(mousePosition);

            VisualTreeHelper.HitTest(SceneViewport, null, HTResult, pointParams);
        }

        private void Grid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = false;
        }

        public HitTestResultBehavior HTResult(System.Windows.Media.HitTestResult rawResult)
        {
            RayHitTestResult rayResult = rawResult as RayHitTestResult;

            if (rayResult != null)
            {
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;

                if (rayMeshResult != null)
                {
                    GeometryModel3D hit = rayMeshResult.ModelHit as GeometryModel3D;
                    _sceneEditorViewModel.SelectedEntity = _visualEntities.First(obj => obj.Value == hit).Key;

                    return HitTestResultBehavior.Stop;
                }

                return HitTestResultBehavior.Continue;
            }

            _sceneEditorViewModel.SelectedEntity = null;
            return HitTestResultBehavior.Stop;
        }

        ~SceneEditor()
        {
            Editor.EditorInstance.SceneEditor.OnSelectionChanged -= OnSelectionChanged;
        }

        private void Grid_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_sceneEditorViewModel.SelectedEntity != null && IsMouseDown)
            {
                Point mousePosition = Mouse.GetPosition(SceneViewport);
                
                _visualEntities[_sceneEditorViewModel.SelectedEntity].Move(mousePosition.X * 0.01f, -mousePosition.Y * 0.01f, 0);
            }
        }
    }
}
