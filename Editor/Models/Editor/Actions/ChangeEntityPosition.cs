using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    /// <summary>
    /// Действие изменения позиции сущности
    /// </summary>
    public class ChangeEntityPosition: IAction
    {
        /// <summary>
        /// Имя редактируемой сущности
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Координаты новой позиции
        /// </summary>
        public Vector2 NewPosition { get; set; }

        /// <summary>
        /// Координаты старой позиции
        /// </summary>
        public Vector2 OldPosition { get; set; }

        public void Do(IEditor editor)
        {
            //editor.GameProject.Entities.First(e => e.Name == EntityName).Components.Where(c => c is Transform)
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }
    }
}
