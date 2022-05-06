using System;
using System.Collections.Generic;
using System.Numerics;
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
            Resources = new List<IResource>();
            Name = "<Untitled Project>";

            Resources.Add(new BaseResource() { Name = "DefaultResource0", FilePath = "/Resources/Images/step.png" } );
            Resources.Add(new BaseResource() { Name = "DefaultResource1", FilePath = "/Resources/Images/sprite.png" });
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

        /// <summary>
        /// Ресурсы, которые может использовать проект
        /// </summary>
        public IList<IResource> Resources { get; private set; }
    }
}
