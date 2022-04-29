using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.GameProject
{
    /// <summary>
    /// Базовый класс системы в игровом проекте
    /// </summary>
    public class BaseSystem : ISystem
    {
        /// <summary>
        /// Название системы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// GUID системы
        /// </summary>
        public Guid Id { get; }

        public BaseSystem()
        {
            Name = "BaseSystem";
            Id = Guid.NewGuid();
        }

    }
}
