///////////////////////////////////////////////////////////
// Room.cs
//
// Автор: karaul0f
// Дата создания: 12.05.20
//
// Игровая сцена.
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiker_Editor.Models
{
    public class Room: ProjectItem
    {
        static private uint _maxId = 0;
        private uint _id;
        public Room()
        {
            _imagePath = "/Resources/Images/room.png";
            _id = _maxId;
            _name = "room" + _id;
            _maxId++;
        }
    }
}
