using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models
{
    /// <summary>
    /// Базовый класс сущности в игровом проекте
    /// </summary>
    public class BaseEntity: IEntity
    {
        /// <summary>
        /// Имя сущности
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// GUID сущности
        /// </summary>
        public Guid Id { get; }

        public BaseEntity()
        {
            Name = "Null";
            Id = new Guid();
        }

    }
}
