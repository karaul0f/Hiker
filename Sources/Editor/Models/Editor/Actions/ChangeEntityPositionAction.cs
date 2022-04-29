using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.GameProject;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor.Actions
{
    /// <summary>
    /// Действие изменения позиции сущности
    /// </summary>
    public class ChangeEntityPositionAction: IAction
    {
        /// <summary>
        /// Имя редактируемой сущности
        /// </summary>
        public string EntityName { get; }

        /// <summary>
        /// Координаты новой позиции
        /// </summary>
        public Vector2 NewPosition { get; }

        /// <summary>
        /// Координаты старой позиции
        /// </summary>
        public Vector2 OldPosition { get; }

        public ChangeEntityPositionAction(IEntity entity, Vector2 newPosition)
        {
            EntityName = entity.Name;
            NewPosition = newPosition;
            OldPosition = entity.VisualComponent.WorldPosition;
        }
        public void Do(IEditor editor)
        {
            VisualComponent vc = editor.GameProject.Entities.First(e => e.Name == EntityName).VisualComponent;
            vc.WorldPosition = NewPosition;
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
