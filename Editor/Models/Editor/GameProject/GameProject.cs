using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor
{
    /// <summary>
    /// Исходные файлы игры, объединенные логической сущностью - проектом
    /// </summary>
    public class GameProject
    {
        /// <summary>
        /// Название проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Все игровые сущности проекта
        /// </summary>
        public IEnumerable<IEntity> Entities { get; private set; }

        /// <summary>
        /// Все доступные компоненты проекта
        /// </summary>
        public IEnumerable<IComponent> Components { get; private set; }

        /// <summary>
        /// Все системы проекта
        /// </summary>
        public IEnumerable<ISystem> Systems { get; private set; }
    }
}
