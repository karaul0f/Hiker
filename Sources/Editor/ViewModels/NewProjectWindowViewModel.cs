using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.ViewModels.Commands;
using HikerEditor.ViewModels.Commands.File;

namespace HikerEditor.ViewModels
{
    public class NewProjectWindowViewModel: ViewModelBase
    {
        public NewProjectParameters Parameters { get; }

        public BrowseDirectoryCommand BrowseDirectoryCommand { get; set; }

        public CreateProjectCommand CreateProjectCommand { get; set; }
        public NewProjectWindowViewModel()
        {
            Parameters = new NewProjectParameters();
            BrowseDirectoryCommand = new BrowseDirectoryCommand();
            CreateProjectCommand = new CreateProjectCommand(Editor);
        }
    }
}
