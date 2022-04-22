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
        /// <summary>
        /// Позиция на сцене
        /// </summary>
        public Vector2 WorldPosition { get; set; }

        /// <summary>
        /// Путь до файла с картинкой, которую будет отображать сущность
        /// </summary>
        public String PathToImage { get; set; }
    }
}
