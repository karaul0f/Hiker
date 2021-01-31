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
