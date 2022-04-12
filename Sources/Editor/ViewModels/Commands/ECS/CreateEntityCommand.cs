using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HikerEditor.Models.Editor;
using HikerEditor.Models.Interfaces;

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
