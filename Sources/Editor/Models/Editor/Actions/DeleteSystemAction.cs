using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    public class DeleteSystemAction: IAction
    {
        /// <summary>
        /// Удаляемая система
        /// </summary>
        private ISystem _system;

        /// <summary>
        /// Удаленная сущность
        /// </summary>
        public ISystem RemovedSystem { get; private set; }

        public DeleteSystemAction(ISystem system)
        {
            _system = system;
        }

        public void Do(IEditor editor)
        {
            editor.GameProject.Systems.Remove(_system);
            RemovedSystem = _system;
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
