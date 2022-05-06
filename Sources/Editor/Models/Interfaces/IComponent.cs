using System;

namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс компонента(ECS) в игровом проекте
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Имя компонента
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Событие изменения параметров компонента
        /// </summary>
        event Action<IComponent> OnComponentChangedEvent;
    }
}
