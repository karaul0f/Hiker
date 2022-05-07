using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.GameProject;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    public class NewResourceAction: IAction
    {
        /// <summary>
        /// Имя нового ресурса
        /// </summary>
        public string ResourceName { get; }

        public IResource Resource { get; }

        public NewResourceAction(string resourceName)
        {
            Resource = new BaseResource() { Name = resourceName, FilePath = "/Resources/Images/sprite.png" };
            ResourceName = resourceName;
        }

        public void Do(IEditor editor)
        {
            editor.GameProject.Resources.Add(Resource);
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
