using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using HikerEditor.Models.Interfaces;

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
            _editor.GameProject.ClearProject();
            _editor.GameProject.Name = parameter.ToString();

            //FIXME: HARDCODE
            _editor.GameProject.Save(@"D:\Workspace\" + parameter.ToString());
            _editor.GameProject.Load(@"D:\Workspace\" + parameter.ToString());
            _editor.LastWorkedDirectory = @"D:\Workspace\" + parameter.ToString();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
