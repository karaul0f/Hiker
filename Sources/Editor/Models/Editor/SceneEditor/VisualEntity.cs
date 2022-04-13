using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.Editor
{
    /// <summary>
    /// Объект отображаемый в редакторе сцены
    /// </summary>
    public class VisualEntity
    {
        public VisualEntity(IEntity entity)
        {
            foreach (var component in entity.Components)
            {
                if (component is VisualComponent visualComponent)
                {
                    Image = new BitmapImage();
                    Image.BeginInit();
                    Image.UriSource = new Uri(visualComponent.PathToImage, UriKind.Relative);
                    Image.EndInit();
                    WorldPosition = visualComponent.WorldPosition;
                }
            }

            Entity = entity;
        }

        /// <summary>
        /// Изображение сущности
        /// </summary>
        public BitmapImage Image { get; set; }

        /// <summary>
        /// Координата сущности в пространстве
        /// </summary>
        public Position WorldPosition { get; set; }

        /// <summary>
        /// Реальная сущность, на который ссылается графическая
        /// </summary>
        public IEntity Entity { get; set; }
    }
}
