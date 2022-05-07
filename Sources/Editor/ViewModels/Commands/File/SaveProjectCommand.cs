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
    /// Команда сохранения проекта
    /// </summary>
    public class SaveProjectCommand: ICommand
    {
        private IEditor _editor;

        public SaveProjectCommand(IEditor editor)
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
            string savePath = null;

            if (_editor.LastWorkedDirectory == null)
            {
                using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                {
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                    if (result == DialogResult.OK)
                        savePath = dialog.SelectedPath;
                }
            }
            else
                savePath = _editor.LastWorkedDirectory;

            _editor.GameProject.Save(savePath);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
