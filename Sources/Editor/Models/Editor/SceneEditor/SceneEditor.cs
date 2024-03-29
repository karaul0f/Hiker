﻿using System;
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

        private IEntity _selectedEntity;
        public SceneEditor(IEditor editor)
        {
        }

        #region Properties

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
