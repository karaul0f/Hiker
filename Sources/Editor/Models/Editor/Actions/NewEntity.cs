using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

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
