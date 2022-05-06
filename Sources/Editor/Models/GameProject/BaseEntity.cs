using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

        public event Action<IEntity> OnEntityChanged;

        public BaseEntity()
        {
            
            Name = "BaseEntity";
            Id = Guid.NewGuid();

            var observableComponents = new ObservableCollection<IComponent>();
            observableComponents.CollectionChanged += ComponentsOnCollectionChanged;

            Components = observableComponents;

            VisualComponent = new VisualComponent() 
            { 
                Image = (BaseResource)Editor.Editor.EditorInstance.GameProject.Resources[0], 
                WorldPosition = new Vector2() { X = 0, Y = 0 }
            };

            Components.Add(VisualComponent);
        }

        private void ComponentsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (IComponent item in e.OldItems)
                    item.OnComponentChangedEvent -= OnComponentChangedHandler;
            }

            if (e.NewItems != null)
            {
                foreach (IComponent item in e.NewItems)
                    item.OnComponentChangedEvent += OnComponentChangedHandler;
            }
        }

        protected void OnComponentChangedHandler(IComponent component)
        {
            OnEntityChanged?.Invoke(this);
        }

    }
}
