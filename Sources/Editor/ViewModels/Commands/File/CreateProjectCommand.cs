using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using HikerEditor.Models.Interfaces;
using HikerEditor.ViewModels.Commands.File;

namespace HikerEditor.ViewModels.Commands
{
    /// <summary>
    /// Команда создания нового проекта
    /// </summary>
    public class CreateProjectCommand: ICommand
    {
        private IEditor _editor;

        public CreateProjectCommand(IEditor editor)
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
            var newProjectParam = parameter as NewProjectParameters;
            if (newProjectParam != null)
            {
                _editor.GameProject.ClearProject();
                _editor.GameProject.Name = newProjectParam.Name;

                string pathToProject = newProjectParam.FilePath + @"\" + newProjectParam.Name;
                _editor.GameProject.Save(pathToProject);
                _editor.GameProject.Load(pathToProject);
                _editor.LastWorkedDirectory = pathToProject;
            }
        }

        public bool CanExecute(object parameter)
        {
            var newProjectParam = parameter as NewProjectParameters;
            if (newProjectParam != null)
            {
                return !String.IsNullOrEmpty(newProjectParam.Name) && !String.IsNullOrEmpty(newProjectParam.FilePath);
            }

            return false;
        }
    }
}
