﻿using System;
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
    public class DeleteEntityCommand: ICommand
    {
        private IEditor _editor;
        public DeleteEntityCommand(IEditor editor)
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
            IEntity entity = (IEntity)parameter;

            if (entity != null)
            {
                var deleteEntityAction = new DeleteEntityAction(entity);
                _editor.Do(deleteEntityAction);
            }
        }

        public bool CanExecute(object parameter)
        {
            return parameter is IEntity;
        }
    }
}