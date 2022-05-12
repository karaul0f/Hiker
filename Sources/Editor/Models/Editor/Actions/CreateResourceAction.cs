using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.GameProject;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    public class CreateResourceAction: IAction
    {
        public IResource Resource { get; }

        public CreateResourceAction(IEditor editor, string resourceName, string filePath = null)
        {
            string destFilePath = null;
            if (filePath != null && editor.LastWorkedDirectory != null)
            {
                string filename = Path.GetFileName(filePath);

                string fullPathToResourceDirectory = editor.LastWorkedDirectory + @"/Resources/";
                if (!Directory.Exists(fullPathToResourceDirectory))
                    Directory.CreateDirectory(fullPathToResourceDirectory);

                System.IO.File.Copy(filePath, editor.LastWorkedDirectory + @"/Resources/" + filename);
                destFilePath = @"/Resources/" + filename;
            }
            else
                destFilePath = @"/Resources/Images/sprite.png";

            Resource = new BaseResource() { Name = resourceName, FilePath = destFilePath };
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
