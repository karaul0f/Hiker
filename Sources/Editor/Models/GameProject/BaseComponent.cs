using System;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.GameProject
{
    /// <summary>
    /// Базовая реализация компонента сущности (ECS)
    /// </summary>
    public abstract class BaseComponent: IComponent
    {
        public string Name => "Base Component";

        /// <summary>
        /// Событие измения параметров компонента
        /// </summary>
        public event Action<IComponent> OnComponentChangedEvent;

        protected void OnComponentChanged()
        {
            OnComponentChangedEvent?.Invoke(this);
        }
    }
}
