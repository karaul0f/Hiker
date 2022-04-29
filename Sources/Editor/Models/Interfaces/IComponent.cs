using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
