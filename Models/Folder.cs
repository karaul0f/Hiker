using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
