using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HikerEditor.Models.Interfaces;
using HikerEditor.Views;

namespace HikerEditor.ViewModels.Commands
{
    /// <summary>
    /// Команда для создания приложения.
    /// </summary>
    public class BuildAppCommand: ICommand
    {
        private IAppBuilder _appBuilder;
        private IEditor _editor;

        public BuildAppCommand(IEditor editor, IAppBuilder builder)
        {
            _appBuilder = builder;
            _editor = editor;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _appBuilder.Build(null, null);
        }

        public bool CanExecute(object parameter)
        {
            return _editor.LastWorkedDirectory != null && !String.IsNullOrEmpty(_editor.LastWorkedDirectory);
        }
    }
}
