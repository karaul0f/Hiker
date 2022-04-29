using System.Collections.Generic;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.GameProject
{
    /// <summary>
    /// Исходные файлы игры, объединенные логической сущностью - проектом
    /// </summary>
    public class Project
    {
        public Project()
        {
            Entities = new List<IEntity>();
            Systems = new List<ISystem>();
            Components = new List<IComponent>();
            Name = "<Untitled Project>";
        }

        /// <summary>
        /// Название проекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Все игровые сущности проекта
        /// </summary>
        public IList<IEntity> Entities { get; private set; }

        /// <summary>
        /// Все доступные компоненты проекта
        /// </summary>
        public IList<IComponent> Components { get; private set; }

        /// <summary>
        /// Все системы проекта
        /// </summary>
        public IList<ISystem> Systems { get; private set; }
    }
}
