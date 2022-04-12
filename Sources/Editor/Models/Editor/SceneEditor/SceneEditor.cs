﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor
{
    /// <summary>
    /// Логика редактора сцены
    /// </summary>
    public class SceneEditor
    {
        private List<VisualEntity> _visualEntities;

        private VisualEntity _selectedEntity;

        public SceneEditor(IEditor editor)
        {
            _visualEntities = new List<VisualEntity>();
            editor.OnActionExecuted += EditorOnOnActionExecuted;
            
        }

        private void EditorOnOnActionExecuted(IAction action)
        {
            if (action is NewEntity)
            {
                VisualEntity ve = new VisualEntity();
                _visualEntities.Add(ve);
                OnEntityAdded?.Invoke(ve);
            }
            else if (action is ChangeEntityPosition)
            {

            }
                
        }

        #region Properties

        /// <summary>
        /// Отображаемые сущности в редакторе сцены
        /// </summary>
        public IEnumerable<VisualEntity> VisualEntities
        {
            get => _visualEntities;
        }

        public VisualEntity SelectedEntity
        {
            get
            {
                return _selectedEntity;
            }
            set
            {
                _selectedEntity = value;
                OnSelectionChanged?.Invoke(value);
            }
        }

        /// <summary>
        /// Событие добавления новой визуальной сущности в редактор сцены
        /// </summary>
        public event Action<VisualEntity> OnEntityAdded;

        /// <summary>
        /// Событие изменения параметров существующей визуальной сущности
        /// </summary>
        public event Action<VisualEntity> OnEntityChanged;

        /// <summary>
        /// Событие переключения на другую сущность редактора
        /// </summary>
        public event Action<VisualEntity> OnSelectionChanged;

        #endregion
    }
}