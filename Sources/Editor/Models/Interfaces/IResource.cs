using System;

namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс для реализации ресурсов (файлов) в проекте
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Название ресурса
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Относительный путь к файлу ресурса
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Событие изменения параметров ресурса
        /// </summary>
        event Action<IResource> OnResourceChanged;
    } 
}
