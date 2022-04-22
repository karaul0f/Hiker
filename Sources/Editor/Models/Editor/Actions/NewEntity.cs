using System;
using System.Linq;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.GameProject;

namespace HikerEditor.Models.Editor.Actions
{
    /// <summary>
    /// Действие создания новой сущности
    /// </summary>
    public class NewEntity: IAction
    {
        /// <summary>
        /// Имя новой сущности
        /// </summary>
        public string NewEntityName { get; set; }

        public IEntity Entity { get; set; }

        public void Do(IEditor editor)
        {
            Entity = new BaseEntity();
            editor.GameProject.Entities.Append(Entity);
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
