﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
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

        private Point3D _mouseToWorldPoint;

        public bool IsMouseDown { get; set; } = false;

        public static readonly DependencyProperty EntitiesProperty = DependencyProperty.Register(
            "Entities",
            typeof(ObservableCollection<IEntity>),
            typeof(SceneEditor),
            new FrameworkPropertyMetadata(null, OnItemSourceChanged));

        public SceneEditor()
        {
            InitializeComponent();
            _visualEntities = new Dictionary<IEntity, GeometryModel3D>();
            _sceneEditorViewModel = new SceneEditorViewModel();
        }


        public ObservableCollection<IEntity> Entities
        {
            get => (ObservableCollection<IEntity>)GetValue(EntitiesProperty);
            set => SetValue(EntitiesProperty, value);
        }

        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                ClearAll();
                return;
            }

            if (e.OldItems != null)
            {
                foreach (IEntity item in e.OldItems)
                {
                    item.OnEntityChanged -= OnEntityChanged;
                    Delete(item);
                }
                    
            }
            
            if (e.NewItems != null)
            {
                foreach (IEntity item in e.NewItems)
                {
                    item.OnEntityChanged += OnEntityChanged;
                    Add(item);
                }
                    
            }
        }

        public void OnEntityChanged(IEntity entity)
        {
            // Наиболее простой метод обновить визуальную сущность.
            // Позже мб стоит заменить на что-то более оптимальное.
            Delete(entity);
            Add(entity);
        }

        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SceneEditor control = (SceneEditor)d;
            var entitiesCollection = (ObservableCollection<IEntity>)e.NewValue;
            entitiesCollection.CollectionChanged += control.OnCollectionChanged;
        }

        private void Add(IEntity entity)
        {
            VisualComponent vc = (VisualComponent)entity.Components[0];
            GeometryModel3D texturedBox = TexturedBox3DBuilder.Create(vc.WorldPosition.X, -vc.WorldPosition.Y, 0, vc.Image.FullFilePath, new System.Windows.Size(vc.Size.X, vc.Size.Y));
            VisualEntities.Children.Add(texturedBox);
            _visualEntities[entity] = texturedBox;


            float z = vc.IsBackground ? 0 : 0.0001f;
            // FIXME: Сбрасывается положение визуального компонента, если он еще не привязан к сцене.
            _visualEntities[entity].Move(entity.VisualComponent.WorldPosition.X,
                entity.VisualComponent.WorldPosition.Y, z);
        }

        private void ClearAll()
        {
            foreach (var model in _visualEntities.Values)
                VisualEntities.Children.Remove(model);

            _visualEntities.Clear();
        }

        private void Delete(IEntity entity)
        {
            VisualEntities.Children.Remove(_visualEntities[entity]);
            _visualEntities.Remove(entity);
        }

        private void Grid_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = true;

            var mousePosition = e.GetPosition(SceneViewport);
            PointHitTestParameters pointParams = new PointHitTestParameters(mousePosition);

            VisualTreeHelper.HitTest(SceneViewport, null, OnMouseClickHandlerImpl, pointParams);
        }

        private HitTestResultBehavior OnMouseClickHandlerImpl(HitTestResult rawResult)
        {
            RayHitTestResult rayResult = rawResult as RayHitTestResult;

            if (rayResult != null)
            {
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;

                if (rayMeshResult != null)
                {
                    GeometryModel3D hit = rayMeshResult.ModelHit as GeometryModel3D;

                    if (ScenePlane.Content == hit)
                        return HitTestResultBehavior.Continue;

                    _sceneEditorViewModel.SelectedEntity = _visualEntities.FirstOrDefault(obj => obj.Value == hit).Key;

                    return HitTestResultBehavior.Stop;
                }

                return HitTestResultBehavior.Continue;
            }

            _sceneEditorViewModel.SelectedEntity = null;
            return HitTestResultBehavior.Stop;
        }

        private void Grid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_sceneEditorViewModel.SelectedEntity != null)
            {
                var selectedTransform = _visualEntities[_sceneEditorViewModel.SelectedEntity].Transform;
                Vector2 newPosition = new Vector2(
                    (float)selectedTransform.Value.OffsetX,
                    (float)selectedTransform.Value.OffsetY);
                _sceneEditorViewModel.MoveSelectedEntity(newPosition);
            }

            IsMouseDown = false;
        }

        private void Grid_OnMouseMove(object sender, MouseEventArgs e)
        {
            UpdateMouseToWorldPosition(e.GetPosition(SceneViewport));
        }

        private void UpdateMouseToWorldPosition(Point mousePosition)
        {
            PointHitTestParameters pointParams = new PointHitTestParameters(mousePosition);

            VisualTreeHelper.HitTest(SceneViewport, null, UpdateMouseToWorldPositionImpl, pointParams);

            if (_sceneEditorViewModel.SelectedEntity != null && IsMouseDown)
            {
                _visualEntities[_sceneEditorViewModel.SelectedEntity].Move(_mouseToWorldPoint.X, _mouseToWorldPoint.Y, 0);
            }
        }

        private HitTestResultBehavior UpdateMouseToWorldPositionImpl(HitTestResult rawResult)
        {
            RayHitTestResult rayResult = rawResult as RayHitTestResult;
            if (rayResult != null)
            {
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;

                if (rayMeshResult != null)
                    _mouseToWorldPoint = rayMeshResult.PointHit;
            }

            return HitTestResultBehavior.Stop;
        }
    }
}
