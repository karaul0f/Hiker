using System;
using System.Collections.Generic;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor
{
    /// <summary>
    /// Логика редактора сцены
    /// </summary>
    public class SceneEditor
    {
        private List<IEntity> _visualEntities;

        private IEntity _selectedEntity;

        public SceneEditor(IEditor editor)
        {
            _visualEntities = new List<IEntity>();
            editor.OnActionExecuted += EditorOnOnActionExecuted;
        }

        private void EditorOnOnActionExecuted(IAction action)
        {
            if (action is NewEntity)
            {
                var newEntityAction = action as NewEntity;
                _visualEntities.Add(newEntityAction.Entity);
                OnEntityAdded?.Invoke(newEntityAction.Entity);
            }
            else if (action is ChangeEntityPosition)
            {

            }
                
        }

        #region Properties

        /// <summary>
        /// Отображаемые сущности в редакторе сцены
        /// </summary>
        public IEnumerable<IEntity> VisualEntities
        {
            get => _visualEntities;
        }

        public IEntity SelectedEntity
        {
            get
            {
                return _selectedEntity;
            }
            set
            {
                if (value != _selectedEntity)
                {
                    _selectedEntity = value;
                    OnSelectionChanged?.Invoke(value);
                }
            }
        }

        /// <summary>
        /// Событие добавления новой визуальной сущности в редактор сцены
        /// </summary>
        public event Action<IEntity> OnEntityAdded;

        /// <summary>
        /// Событие изменения параметров существующей визуальной сущности
        /// </summary>
        public event Action<IEntity> OnEntityChanged;

        /// <summary>
        /// Событие переключения на другую сущность редактора
        /// </summary>
        public event Action<IEntity> OnSelectionChanged;

        #endregion
    }
}
