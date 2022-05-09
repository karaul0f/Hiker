using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace HikerEditor.ViewModels.Commands.File
{
    /// <summary>
    /// Команда выбора директории
    /// </summary>
    public class BrowseDirectoryCommand: ICommand
    {
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
                    var parameters = parameter as NewProjectParameters;
                    if(parameters != null)
                        parameters.FilePath = dialog.SelectedPath;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
