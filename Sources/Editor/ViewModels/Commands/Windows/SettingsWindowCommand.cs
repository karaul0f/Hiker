using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HikerEditor.Views;

namespace HikerEditor.ViewModels.Commands.Windows
{
    /// <summary>
    /// Команда открытия настроек программы
    /// </summary>
    public class SettingsWindowCommand: ICommand
    {
        SettingsWindow _settingsWindow;

        public SettingsWindowCommand()
        {
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _settingsWindow = new SettingsWindow();
            _settingsWindow.Show();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
