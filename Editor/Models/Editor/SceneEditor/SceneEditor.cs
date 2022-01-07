using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikerEditor.Models.Editor
{
    /// <summary>
    /// Логика редактора сцены
    /// </summary>
    class SceneEditor
    {
        private List<VisualEntity> _visualEntities;

        public SceneEditor()
        {
            _visualEntities = new List<VisualEntity>();
        }

        #region Properties

        /// <summary>
        /// Отображаемые сущности в редакторе сцены
        /// </summary>
        public IEnumerable<VisualEntity> VisualEntities
        {
            get => _visualEntities;
        }

        /// <summary>
        /// Событие добавления новой визуальной сущности в редактор сцены
        /// </summary>
        public event Action<VisualEntity> OnEntityAdded;

        #endregion
    }
}
