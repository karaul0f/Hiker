using System.Collections.ObjectModel;

namespace Hiker_Editor.Models
{
    public class Folder: ProjectItem
    {
        public Folder(): base()
        {
            _imagePath = "/Resources/Images/folder.png";
            Items = new ObservableCollection<ProjectItem>();
        }

        public override bool IsEditable
        {
            get { return false; }
            set {  }
        }
    }
}
