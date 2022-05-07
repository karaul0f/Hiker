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

        public PlayAppCommand(IAppBuilder builder, IGame game)
        {
            _appBuilder = builder;
            _game = game;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _appBuilder.Build(null, null);
            _game.Play(null);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
