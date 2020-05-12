using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Hiker_Editor.Models
{
    public class Sprite: ProjectItem
    {
        static public uint id = 0;
        public Sprite()
        {
            _imagePath = "/Resources/Images/sprite.png";
            _name = "sprite" + id;
            id++;
        }
    }
}
