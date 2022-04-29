using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using HikerEditor.Models.Interfaces;
using IComponent = HikerEditor.Models.Interfaces.IComponent;

namespace HikerEditor.Models.GameProject
{
    /// <summary>
    /// Базовый класс сущности в игровом проекте
    /// </summary>
    public class BaseEntity: IEntity
    {
        public string Name { get; set; }

        public IList<IComponent> Components { get; set; }

        public Guid Id { get; }

        public VisualComponent VisualComponent { get; }

        public BaseEntity()
        {
            Name = "BaseEntity";
            Id = Guid.NewGuid();
            Components = new List<IComponent>();
            VisualComponent = new VisualComponent()
                { PathToImage = "/Resources/Images/sprite.png", WorldPosition = new Vector2() { X = 0, Y = 0 } };
            Components.Add(VisualComponent);
        }

    }
}
