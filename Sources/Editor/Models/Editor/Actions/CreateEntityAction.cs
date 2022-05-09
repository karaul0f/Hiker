using System;
using System.Linq;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.GameProject;

namespace HikerEditor.Models.Editor.Actions
{
    /// <summary>
    /// Действие создания новой сущности
    /// </summary>
    public class CreateEntityAction: IAction
    {
        /// <summary>
        /// Имя новой сущности
        /// </summary>
        public string EntityName { get; }

        public IEntity Entity { get; }

        public CreateEntityAction(string entityName)
        {
            Entity = new BaseEntity();
            EntityName = entityName;
        }

        public void Do(IEditor editor)
        {
            Entity.Name = EntityName;
            editor.GameProject.Entities.Add(Entity);
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
