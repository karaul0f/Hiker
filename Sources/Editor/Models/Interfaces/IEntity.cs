using System;
using System.Collections.Generic;
using HikerEditor.Models.GameProject;

namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс сущности(ECS) в игровом проекте
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// GUID сущности
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Имя сущности
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Компоненты, привязанные к сущности
        /// </summary>
        IList<IComponent> Components { get; }

        /// <summary>
        /// Визуальный компонент сущности
        /// </summary>
        VisualComponent VisualComponent { get; }
    }
}
