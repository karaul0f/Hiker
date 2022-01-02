using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void Do();

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
