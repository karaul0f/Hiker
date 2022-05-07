using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using HikerEditor.ViewModels.Commands;

namespace HikerEditor.ViewModels
{
    public class NewProjectWindowViewModel: ViewModelBase
    {
        private String _projectName;

        public String ProjectName
        {
            get => _projectName;
            set
            {
                _projectName = value;
                OnPropertyChanged();
            }
        }

        public CreateProjectCommand CreateProjectCommand { get; set; }
        public NewProjectWindowViewModel()
        {
            CreateProjectCommand = new CreateProjectCommand(Editor);
        }
    }
}
