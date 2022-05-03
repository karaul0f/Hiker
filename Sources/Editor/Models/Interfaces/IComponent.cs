
namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс компонента(ECS) в игровом проекте
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Имя компонента
        /// </summary>
        string Name { get; }
    }
}
