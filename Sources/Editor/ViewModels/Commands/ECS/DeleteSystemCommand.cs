using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.ViewModels.Commands.ECS
{
    /// <summary>
    /// Действие удаления системы
    /// </summary>
    public class DeleteSystemCommand: ICommand
    {
        private IEditor _editor;
        public DeleteSystemCommand(IEditor editor)
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
            ISystem system = (ISystem)parameter;

            if (system != null)
            {
                var deleteSystemAction = new DeleteSystemAction(system);
                _editor.Do(deleteSystemAction);
            }
        }

        public bool CanExecute(object parameter)
        {
            return parameter is ISystem;
        }
    }
}
