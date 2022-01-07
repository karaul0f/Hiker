using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

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
            GameProject = new GameProject();
        }

        #region Properties

        /// <summary>
        /// Изменяемые ресурсы внутри редактора (игровой проект)
        /// </summary>
        public GameProject GameProject { get; set; }

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

    }
}
