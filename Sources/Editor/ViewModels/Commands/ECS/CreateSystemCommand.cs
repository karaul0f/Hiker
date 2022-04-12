using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HikerEditor.Models.Editor;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.ViewModels.Commands.ECS
{
    /// <summary>
    /// Команда создания системы для проекта
    /// </summary>
    public class CreateSystemCommand: ICommand
    {
        private ObservableCollection<ISystem> _systemStorage;

        public CreateSystemCommand(ObservableCollection<ISystem> systemStorage)
        {
            _systemStorage = systemStorage;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {

            string systemName = parameter != null ?
                parameter.ToString() :
                "System" + _systemStorage.Count;

            _systemStorage.Add(new BaseSystem() { Name = systemName });
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
