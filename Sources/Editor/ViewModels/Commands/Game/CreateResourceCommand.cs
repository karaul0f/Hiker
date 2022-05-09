using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.ViewModels.Commands.Game
{
    public class CreateResourceCommand: ICommand
    {
        private IEditor _editor;

        public CreateResourceCommand(IEditor editor)
        {
            _editor = editor;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            string resourceName = parameter != null ?
                parameter.ToString() :
                "Resource" + _editor.GameProject.Resources.Count;

            string pathToResourceForLoad = null;
            if (_editor.LastWorkedDirectory != null)
            {
                using (var dialog = new System.Windows.Forms.OpenFileDialog())
                {
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        pathToResourceForLoad = dialog.FileName;
                    }
                }
            }
            
            var newResourceAction = new CreateResourceAction(_editor, resourceName, pathToResourceForLoad);
            _editor.Do(newResourceAction);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
