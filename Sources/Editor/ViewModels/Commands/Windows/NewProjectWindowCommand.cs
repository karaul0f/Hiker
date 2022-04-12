using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HikerEditor.Views;

namespace HikerEditor.ViewModels.Commands
{
    /// <summary>
    /// Команда для открытия окна для создания нового проекта
    /// </summary>
    public class NewProjectWindowCommand: ICommand
    {
        NewProjectWindow _newProjectWindow;

        public NewProjectWindowCommand()
        {
            _newProjectWindow = new NewProjectWindow();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _newProjectWindow = new NewProjectWindow();
            _newProjectWindow.Show();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
