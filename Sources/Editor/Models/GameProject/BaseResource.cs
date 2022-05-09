using System;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.GameProject
{
    public class BaseResource: IResource, ISelectable
    {
        private string _name;
        private string _filePath;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnResourceChanged?.Invoke(this);
            } 
        }

        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnResourceChanged?.Invoke(this);
            }
        }

        /// <summary>
        /// Полный путь к файлу
        /// </summary>
        public string FullFilePath
        {
            get => Editor.Editor.EditorInstance.LastWorkedDirectory + _filePath;
        }

        public event Action<IResource> OnResourceChanged;
    }
}
