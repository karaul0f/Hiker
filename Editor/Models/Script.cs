///////////////////////////////////////////////////////////
// Script.cs
//
// Автор: karaul0f
// Дата создания: 12.05.20
//
// Класс для хранения/обработки игрового скрипта.
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiker_Editor.Models
{
    public class Script: ProjectItem
    {
        static private uint _maxId = 0;
        private uint _id;
        public Script()
        {
            _imagePath = "/Resources/Images/script.png";
            _id = _maxId;
            _name = "script" + _id;
            _maxId++;
        }

    }
}
