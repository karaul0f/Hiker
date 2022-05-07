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
        private IEntity _selectedEntity;

        /// <summary>
        /// Выбранная сущность в редакторе
        /// </summary>
        public IEntity SelectedEntity
        {
            get => _selectedEntity;
            set
            {
                _selectedEntity = value;
                // FIXME: Переосмыслить заглушку. Сейчас при выделении других объектов сбрасывается главное значение в редакторе.
                if(_selectedEntity != null)
                    Editor.SceneEditor.SelectedObject = (ISelectable)value;
                OnPropertyChanged();
            }
        }

        public SceneEditorViewModel()
        {
           Editor.SceneEditor.OnSelectionChanged += SceneEditorOnSelectionChanged;
        }

        private void SceneEditorOnSelectionChanged(ISelectable newSelectedObject)
        {
            if (newSelectedObject is IEntity)
                SelectedEntity = newSelectedObject as IEntity;
            else
                SelectedEntity = null;
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
