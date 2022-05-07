using System;
using HikerEditor.Models.Interfaces;
using HikerEditor.Models.GameProject;

namespace HikerEditor.Models.Editor
{
    /// <summary>
    ///  Редактор игры в целом (вся логика)
    /// </summary>
    public class Editor : IEditor
    {
        private static Editor _instance;

        private Editor()
        {
            GameProject = new Project();
            SceneEditor = new SceneEditor(this);
        }

        #region Properties

        /// <summary>
        /// Изменяемые ресурсы внутри редактора (игровой проект)
        /// </summary>
        public Project GameProject { get; set; }

        /// <summary>
        /// Последняя директория, с которой работал редактор.
        /// </summary>
        public String LastWorkedDirectory { get; set; }

        /// <summary>
        /// Логика визуального редактора сцены
        /// </summary>
        public SceneEditor SceneEditor { get; set; }

        /// <summary>
        /// Получение экземпляра редактора (синглтон)
        /// </summary>
        public static Editor EditorInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Editor();

                return _instance;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Выполнить действие
        /// </summary>
        /// <param name="action"></param>
        public void Do(IAction action)
        {
			// TODO Реализовать функционал отменяемых событий
            action.Do(this);
            OnActionExecuted?.Invoke(action);
        }

        /// <summary>
        /// Отменить предыдущее действие
        /// </summary>
        public void Undo()
        {
            // TODO Реализовать функционал отменяемых событий
        }

        /// <summary>
        /// Вернуть отмененное действие
        /// </summary>
        public void Redo()
        {
            // TODO Реализовать функционал отменяемых событий
        }

        #endregion

        /// <summary>
        /// Выполнили действие (отмена действия тоже является выполнением действия)
        /// </summary>
        public event Action<IAction> OnActionExecuted;
    }
}
