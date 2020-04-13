using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;

using Hiker_Editor.Models;
using Hiker_Editor.Views;

namespace Hiker_Editor.ViewModels
{
    public enum Folders { Sprites = 0, Scripts = 1, Objects = 2, Rooms = 3 };
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand _openAbout;
        private RelayCommand _openSettings;
        private RelayCommand _exitProgram;
        private RelayCommand _newProject;
        private RelayCommand _openProject;
        public ObservableCollection<ProjectItem> StructureProject { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public bool _isAvailableCreate = true;
        public bool _isAvailableEdit = true;
        public bool _isAvailableDelete = true;

        public bool IsAvailableCreate
        {
            get
            {
                return _isAvailableCreate;
            }
        }

        public bool IsAvailableEdit
        {
            get
            {
                return _isAvailableEdit;
            }
        }

        public bool IsAvailableDelete
        {
            get
            {
                return _isAvailableDelete;
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MainWindowViewModel()
        {
            StructureProject = ProjectItem.InitializationStructureProject();
            StructureProject[(int)Folders.Sprites].Items.Add(new ProjectItemBuilder().SetType(ProjectItemType.File).SetName("TestElem"));
        }

        public RelayCommand OpenAbout
        {
            get
            {
                return _openAbout ??
                  (_openAbout = new RelayCommand(obj =>
                  {
                      AboutWindow aboutWindow = new AboutWindow();
                      aboutWindow.Show();
                  }));
            }
        }

        public RelayCommand OpenSettings
        {
            get
            {
                return _openSettings ??
                  (_openSettings = new RelayCommand(obj =>
                  {
                      SettingsWindow settingWindow = new SettingsWindow();
                      settingWindow.Show();
                  }));
            }
        }

        public RelayCommand ExitProgram
        {
            get
            {
                return _exitProgram ??
                  (_exitProgram = new RelayCommand(obj =>
                  {
                      Application.Current.Shutdown();
                  }));
            }
        }

        public RelayCommand NewProject
        {
            get
            {
                return _newProject ??
                  (_newProject = new RelayCommand(obj =>
                  {
                      //SaveFileDialog openFileDialog = new SaveFileDialog();
                      //openFileDialog.ShowDialog();
                  }));
            }
        }

        public RelayCommand OpenProject
        {
            get
            {
                return _openProject ??
                  (_openProject = new RelayCommand(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.ShowDialog();
                  }));
            }
        }
    }
}
