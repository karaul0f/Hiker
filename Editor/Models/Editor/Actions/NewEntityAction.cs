using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    public class NewEntityAction: IAction
    {
        /// <summary>
        /// Имя новой сущности
        /// </summary>
        public string NewEntityName { get; set; }

        public void Do(IEditor editor)
        {
            editor.GameProject.Entities.Append(new BaseEntity() { Name = NewEntityName } );
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
