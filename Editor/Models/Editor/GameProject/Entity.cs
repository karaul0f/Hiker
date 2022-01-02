using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Hiker_Editor.Models
{
    /// <summary>
    /// Класс сущности в игровом проекте
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Имя сущности
        /// </summary>
        public string Name { get; set; }

        public Entity()
        {
            Name = "Null";
        }

    }
}
