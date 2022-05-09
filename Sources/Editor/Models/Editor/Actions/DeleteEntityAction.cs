using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    /// <summary>
    /// Действие удаления сущности
    /// </summary>
    public class DeleteEntityAction: IAction
    {
        /// <summary>
        /// Удаляемой сущность
        /// </summary>
        private IEntity _entity;

        /// <summary>
        /// Удаленная сущность
        /// </summary>
        public IEntity RemovedEntity { get; private set; }

        public DeleteEntityAction(IEntity entity)
        {
            _entity = entity;
        }

        public void Do(IEditor editor)
        {
            editor.GameProject.Entities.Remove(_entity);
            RemovedEntity = _entity;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }
    }
}
