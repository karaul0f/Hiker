using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HikerEditor.Models.Editor
{
    /// <summary>
    /// Объект отображаемый в редакторе сцены
    /// </summary>
    public class VisualEntity
    {
        public VisualEntity()
        {
            Image = new BitmapImage();
            Image.BeginInit();
            Image.UriSource = new Uri("/Resources/Images/sprite.png", UriKind.Relative);
            Image.EndInit();
            WorldPosition = new Position() { X = 0, Y = 0 };
        }

        /// <summary>
        /// Изображение сущности
        /// </summary>
        public BitmapImage Image { get; set; }

        /// <summary>
        /// Координата сущности в пространстве
        /// </summary>
        public Position WorldPosition { get; set; }
    }
}
