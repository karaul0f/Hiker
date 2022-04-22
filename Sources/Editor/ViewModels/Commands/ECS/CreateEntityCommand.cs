using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.GameProject;

namespace HikerEditor.ViewModels.Commands.ECS
{
    /// <summary>
    /// Команда создания сущности для проекта
    /// </summary>
    public class CreateEntityCommand: ICommand
    {
        private ObservableCollection<IEntity> _entityStorage;

        public CreateEntityCommand(ObservableCollection<IEntity> entityStorage)
        {
            _entityStorage = entityStorage;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            string entityName = parameter != null ? 
                parameter.ToString() : 
                "Entity" + _entityStorage.Count;

            _entityStorage.Add(new BaseEntity() { Name = entityName });
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
