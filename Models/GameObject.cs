using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiker_Editor.Models
{
    public class GameObject: ProjectItem
    {
        static private uint _maxId = 0;
        private uint _id;

        public GameObject()
        {
            _imagePath = "/Resources/Images/object.png";
            _id = _maxId;
            _name = "sprite" + _id;
            _maxId++;
        }

        public uint Id
        {
            private set { }
            get
            {
                return _id;
            }
        }
    }
}
