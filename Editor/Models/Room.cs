﻿namespace Hiker_Editor.Models
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
