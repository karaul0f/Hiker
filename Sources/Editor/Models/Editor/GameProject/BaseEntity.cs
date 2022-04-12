﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using HikerEditor.Models.Interfaces;
using IComponent = HikerEditor.Models.Interfaces.IComponent;

namespace HikerEditor.Models.Editor
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
        /// Компоненты, привязанные к сущности
        /// </summary>
        public IEnumerable<IComponent> Components { get; set; }

        /// <summary>
        /// GUID сущности
        /// </summary>
        public Guid Id { get; }

        public BaseEntity()
        {
            Name = "BaseEntity";
            Id = Guid.NewGuid();
            Components = new List<IComponent>();
        }

    }
}
