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
        public Editor()
        {

        }

        #region Properties

        /// <summary>
        /// Изменяемые ресурсы внутри редактора (игровой проект)
        /// </summary>
        public GameProject GameProject { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Выполнить действие
        /// </summary>
        /// <param name="action"></param>
        public void Do(IAction action)
        {
            // TODO Реализовать функционал отменяемых событий
            action.Do();
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
