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
        /// <summary>
        /// Изменяемые ресурсы внутри редактора (игровой проект)
        /// </summary>
        public GameProject GameProject;

    }
}
