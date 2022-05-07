using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    public class DeleteResourceAction: IAction
    {
        /// <summary>
        /// Имя новой сущности
        /// </summary>
        private IResource _resource;

        public IResource RemovedResource { get; private set; }

        public DeleteResourceAction(IResource resource)
        {
            _resource = resource;
        }

        public void Do(IEditor editor)
        {
            editor.GameProject.Resources.Remove(_resource);
            RemovedResource = _resource;
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
