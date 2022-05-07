using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikerEditor.Models.Interfaces
{
    /// <summary>
    /// Интерфейс взаимодействия с игрой
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Запустить игру
        /// </summary>
        /// <param name="pathToGame">Путь к запускаемому файлу игры</param>
        void Play(string pathToGame);
    }
}
