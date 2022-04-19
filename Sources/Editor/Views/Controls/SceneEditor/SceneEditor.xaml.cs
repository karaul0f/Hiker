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
using HikerEditor.Utils;

namespace HikerEditor.Views.Controls
{
    /// <summary>
	/// Interaction logic for SceneEditor.xaml
	/// </summary>
	public partial class SceneEditor : UserControl
    {
        public static readonly DependencyProperty EntitiesProperty;

        private Dictionary<IEntity, GeometryModel3D> _visualEntities;
        private IEntity _selectedEntity;

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
            Editor.EditorInstance.SceneEditor.OnSelectionChanged += OnExternalSelectionChanged;
            _selectedEntity = Editor.EditorInstance.SceneEditor.SelectedEntity;
        }

        private void OnExternalSelectionChanged(IEntity entity)
        {
            throw new NotImplementedException();
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
            GeometryModel3D texturedBox = TexturedBox3DBuilder.Create(vc.WorldPosition.X, -vc.WorldPosition.Y, 0, vc.PathToImage, new System.Windows.Size(1, 1));
            VisualEntities.Children.Add(texturedBox);
            _visualEntities[entity] = texturedBox;
        }

        public void Delete(IEntity entity)
        {
            _visualEntities.Remove(entity);
        }

        private void Grid_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(SceneViewport);
            Point3D testPoint3D = new Point3D(mousePosition.X, mousePosition.Y, 0);
            Vector3D testDirection = new Vector3D(mousePosition.X, mousePosition.Y, 10);
            PointHitTestParameters pointparams = new PointHitTestParameters(mousePosition);

            VisualTreeHelper.HitTest(SceneViewport, null, HTResult, pointparams);
        }

        public HitTestResultBehavior HTResult(System.Windows.Media.HitTestResult rawresult)
        {
            RayHitTestResult rayResult = rawresult as RayHitTestResult;

            if (rayResult != null)
            {
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;

                if (rayMeshResult != null)
                {
                    GeometryModel3D hit = rayMeshResult.ModelHit as GeometryModel3D;
                    _selectedEntity = _visualEntities.First(obj => obj.Value == hit).Key;
                    return HitTestResultBehavior.Continue;
                }
            }

            return HitTestResultBehavior.Stop;
        }

        ~SceneEditor()
        {
            Editor.EditorInstance.SceneEditor.OnSelectionChanged -= OnExternalSelectionChanged;
        }

    }
}
