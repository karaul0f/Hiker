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

        private ISelectable _selectedObject;
        public SceneEditor(IEditor editor)
        {
        }

        #region Properties

        public ISelectable SelectedObject
        {
            get
            {
                return _selectedObject;
            }
            set
            {
                if (value != _selectedObject)
                {
                    _selectedObject = value;
                    OnSelectionChanged?.Invoke(value);
                }
            }
        }

        /// Событие переключения на другую сущность редактора
        /// </summary>
        public event Action<ISelectable> OnSelectionChanged;

        #endregion
    }
}
