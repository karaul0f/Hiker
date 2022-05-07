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
    public class CreateResourceCommand: ICommand
    {
        private ObservableCollection<IResource> _resourseStorage;
        private IEditor _editor;

        public CreateResourceCommand(IEditor editor, ObservableCollection<IResource> resourseStorage)
        {
            _editor = editor;
            _resourseStorage = resourseStorage;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            string resourceName = parameter != null ?
                parameter.ToString() :
                "Resource" + _resourseStorage.Count;

            var newResourceAction = new NewResourceAction(resourceName);
            _editor.Do(newResourceAction);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
