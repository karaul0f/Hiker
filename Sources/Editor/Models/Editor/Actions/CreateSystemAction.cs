using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.GameProject;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    public class CreateSystemAction: IAction
    {
        /// <summary>
        /// Имя новой системы
        /// </summary>

        public ISystem System { get; }

        public CreateSystemAction(string systemName)
        {
            System = new BaseSystem() { Name = systemName };
        }

        public void Do(IEditor editor)
        {
            editor.GameProject.Systems.Add(System);
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
