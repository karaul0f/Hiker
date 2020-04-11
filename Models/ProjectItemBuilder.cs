using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Hiker_Editor.Models
{
    public enum ProjectItemType { Folder, File }
    public class ProjectItemBuilder
    {
        private ProjectItem _projectItem;
        public ProjectItemBuilder()
        {
            _projectItem = new ProjectItem();
        }

        public ProjectItemBuilder SetType(ProjectItemType projectItemType)
        {
            if (projectItemType == ProjectItemType.Folder)
            {
                _projectItem.Items = new ObservableCollection<ProjectItem>();
                _projectItem.ItemsOperation[0].IsEnabled = true;
                _projectItem.ItemsOperation[1].IsEnabled = false;
                _projectItem.ItemsOperation[2].IsEnabled = false;
                SetImage("/Resources/Images/folder.png");
            }
            else
            {
                _projectItem.ItemsOperation[0].IsEnabled = false;
                _projectItem.ItemsOperation[1].IsEnabled = true;
                _projectItem.ItemsOperation[2].IsEnabled = true;
                _projectItem.Items = null;
                SetImage("/Resources/Images/file.png");
            }
            return this;
        }

        public ProjectItemBuilder SetName(string name)
        {
            _projectItem.Name = name;
            return this;
        }

        public ProjectItemBuilder SetImage(string path)
        {
            _projectItem.ImagePath = path;
            return this;
        }

        public static implicit operator ProjectItem(ProjectItemBuilder builder)
        {
            return builder._projectItem;
        }
    }
}
