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

        public PlayAppCommand(IAppBuilder builder)
        {
            _appBuilder = builder;
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
            return true;
        }
    }
}
