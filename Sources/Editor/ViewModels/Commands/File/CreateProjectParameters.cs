using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikerEditor.ViewModels.Commands.File
{
    /// <summary>
    /// Параметры нового проекта
    /// </summary>
    public class NewProjectParameters : ViewModelBase
    {
        private string _name;
        private string _filePath;

        public NewProjectParameters()
        {
            _filePath = @"C:\Workspace\";
        }

        /// <summary>
        /// Название проекта
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Путь к проекту
        /// </summary>
        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged();
            }
        }
    }
}
