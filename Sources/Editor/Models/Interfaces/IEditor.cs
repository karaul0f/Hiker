using System;
using HikerEditor.Models.Editor;
using HikerEditor.Models.GameProject;

namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс взаимодействия с редактором
    /// </summary>
    public interface IEditor
    {
        /// <summary>
        /// Текущий редактируемый игровой проект
        /// </summary>
        Project GameProject { get; }

        /// <summary>
        /// Текущая игровая сцена для редактирования
        /// </summary>
        SceneEditor SceneEditor { get; }

        /// <summary>
        /// Выполнить действие
        /// </summary>
        /// <param name="action"></param>
        void Do(IAction action);

        /// <summary>
        /// Отменить предыдущее действие
        /// </summary>
        void Undo();

        /// <summary>
        /// Вернуть отмененное действие
        /// </summary>
        void Redo();

        /// <summary>
        /// Выполнили действие (отмена действия тоже является выполнением действия)
        /// </summary>
        event Action<IAction> OnActionExecuted;

    }
}
