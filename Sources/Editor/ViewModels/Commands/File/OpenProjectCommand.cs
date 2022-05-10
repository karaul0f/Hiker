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
    /// Команда открытия проекта
    /// </summary>
    public class OpenProjectCommand: ICommand
    {
        private IEditor _editor;

        public OpenProjectCommand(IEditor editor)
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
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _editor.LastWorkedDirectory = dialog.SelectedPath;
                    _editor.GameProject.Load(dialog.SelectedPath);
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
