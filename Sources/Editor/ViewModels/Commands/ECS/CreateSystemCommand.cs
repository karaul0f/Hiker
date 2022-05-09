using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.GameProject;

namespace HikerEditor.ViewModels.Commands.ECS
{
    /// <summary>
    /// Команда создания системы для проекта
    /// </summary>
    public class CreateSystemCommand: ICommand
    {
        private IEditor _editor;

        public CreateSystemCommand(IEditor editor)
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

            string systemName = parameter != null ?
                parameter.ToString() :
                "System" + _editor.GameProject.Systems.Count;

            var createSystemAction = new CreateSystemAction(systemName);
            _editor.Do(createSystemAction);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
