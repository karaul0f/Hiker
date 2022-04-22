using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.GameProject;

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
