using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HikerEditor.Models.Editor.Actions;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.ViewModels.Commands.Game
{
    public class DeleteResourceCommand : ICommand
    {
        private ObservableCollection<IResource> _resourceStorage;
        private IEditor _editor;
        public DeleteResourceCommand(IEditor editor, ObservableCollection<IResource> resourceStorage)
        {
            _editor = editor;
            _resourceStorage = resourceStorage;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            IResource resource = (IResource)parameter;

            if (resource != null)
            {
                var deleteResourceAction = new DeleteResourceAction(resource);
                _editor.Do(deleteResourceAction);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
