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
        private bool _visible, _solid;
        public GameObject()
        {
            _imagePath = "/Resources/Images/object.png";
            _id = _maxId;
            _name = "object" + _id;
            _maxId++;
            _visible = true;
            _solid = true;
        }

        public uint Id
        {
            private set { }
            get
            {
                return _id;
            }
        }

        public bool Visible
        {
            set 
            {
                _visible = value;
                OnPropertyChanged();
            }
            get
            {
                return _visible;
            }
        }

        public bool Solid
        {
            set
            {
                _solid = value;
                OnPropertyChanged();
            }
            get
            {
                return _solid;
            }
        }
    }
}
