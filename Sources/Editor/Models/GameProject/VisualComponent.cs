using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.GameProject
{
    /// <summary>
    /// Визуальный компонент сущности, который описывает ее положение на сцене и
    /// графическое представление в виде картинки.
    /// </summary>
    public class VisualComponent: IComponent
    {
        public string Name => "Visual Component";
        /// <summary>
        /// Позиция на сцене
        /// </summary>
        public Vector2 WorldPosition { get; set; }

        /// <summary>
        /// Картинка, которую будет отображать сущность
        /// </summary>
        public BaseResource Image { get; set; }
    }
}
