using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Hiker_Editor.Models
{
    class ProjectItemBuilder
    {
        private ProjectItem projectItem;
        ProjectItemBuilder()
        {
            projectItem = new ProjectItem();
        }
        public ProjectItemBuilder SetName(string name)
        {
            projectItem.Name = name;
            return this;
        }
        public ProjectItemBuilder SetImage(string path)
        {
            projectItem.ImagePath = path;
            return this;
        }
        public ProjectItemBuilder AddItemOperation(string header)
        {
            #if FEATURE_ADDITEMOPERATION
            if (projectItem.ItemsOperation == null)
                projectItem.ItemsOperation = new ObservableCollection<MenuItem>();
            #endif
            return this;
        }
        public static implicit operator ProjectItem(ProjectItemBuilder builder)
        {
            return builder.projectItem;
        }
    }
}
