using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using HikerEditor.Models.Editor;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;
using HikerEditor.Utils;

namespace HikerEditor.ViewModels
{
    /// <summary>
    /// ВьюМодель редактора сцены
    /// </summary>
    public class SceneEditorViewModel: ViewModelBase
    {
        /// <summary>
        /// Выбранная сущность в редакторе
        /// </summary>
        public IEntity SelectedEntity
        {
            get => Editor.SceneEditor.SelectedEntity;
            set
            {
                Editor.SceneEditor.SelectedEntity = value;
                OnPropertyChanged();
            }
        }

        public SceneEditorViewModel()
        {
           Editor.SceneEditor.OnSelectionChanged += SceneEditorOnSelectionChanged;
        }

        private void SceneEditorOnSelectionChanged(IEntity newEntity)
        {
            SelectedEntity = newEntity;
        }

        /// <summary>
        /// Переместить выделенную сущность на другую позицию в игровом мире
        /// </summary>
        /// <param name="newPosition">Новая позиция в игровом мире</param>
        public void MoveSelectedEntity(Vector2 newPosition)
        {
            var changeEntityPosition = new ChangeEntityPositionAction(SelectedEntity, newPosition);
            Editor.Do(changeEntityPosition);
        }

        ~SceneEditorViewModel()
        {
            Editor.SceneEditor.OnSelectionChanged -= SceneEditorOnSelectionChanged;
        }
    }
}
