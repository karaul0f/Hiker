using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        string Name { get; }

        /// <summary>
        /// Компоненты, привязанные к сущности
        /// </summary>
        IEnumerable<IComponent> Components { get; }
    }
}
