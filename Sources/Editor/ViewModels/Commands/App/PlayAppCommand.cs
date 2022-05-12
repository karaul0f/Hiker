using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.ViewModels.Commands
{
    /// <summary>
    /// Команда для запуска приложения.
    /// </summary>
    public class PlayAppCommand : ICommand
    {
        private IAppBuilder _appBuilder;
        private IGame _game;
        private IEditor _editor;

        public PlayAppCommand(IEditor editor, IAppBuilder builder, IGame game)
        {
            _appBuilder = builder;
            _game = game;
            _editor = editor;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _editor.GameProject.Save(_editor.LastWorkedDirectory);
            _appBuilder.Build(_editor.GameProject, _editor.LastWorkedDirectory);
            _game.Play(_editor.LastWorkedDirectory);
        }

        public bool CanExecute(object parameter)
        {
            return _editor.LastWorkedDirectory != null && !String.IsNullOrEmpty(_editor.LastWorkedDirectory);
        }
    }
}
