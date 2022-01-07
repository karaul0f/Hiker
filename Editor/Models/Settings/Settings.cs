using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HikerEditor.Models.Settings
{
    /// <summary>
    /// Класс с настройками редактора
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Путь к папке с Visual Studio
        /// </summary>
        public string PathToMsBuild { get; set; }

        /// <summary>
        /// Текущая локализация
        /// </summary>
        private string Localization { get; set; }
    }
}
