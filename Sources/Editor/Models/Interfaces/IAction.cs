
namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс какого-либо отменяемого события в редакторе
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Выполнить действие
        /// </summary>
        void Do(IEditor editor);

        /// <summary>
        /// Отменить действие
        /// </summary>
        void Undo();

        /// <summary>
        /// Вернуть действие
        /// </summary>
        void Redo();
    }
}
