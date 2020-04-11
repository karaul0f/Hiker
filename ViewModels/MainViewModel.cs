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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<ProjectItem> StructureProject { get; set; }
        public MainWindowViewModel()
        {
            StructureProject = ProjectItem.InitializationStructureProject();
            StructureProject[(int)Folders.Sprites].Items.Add(new ProjectItemBuilder().SetType(ProjectItemType.File).SetName("TestElem"));
        }

        private RelayCommand openAbout;
        public RelayCommand OpenAbout
        {
            get
            {
                return openAbout ??
                  (openAbout = new RelayCommand(obj =>
                  {
                      AboutWindow aboutWindow = new AboutWindow();
                      aboutWindow.Show();
                  }));
            }
        }

        private RelayCommand openSetting;
        public RelayCommand OpenSetting
        {
            get
            {
                return openSetting ??
                  (openSetting = new RelayCommand(obj =>
                  {
                      SettingWindow settingWindow = new SettingWindow();
                      settingWindow.Show();
                  }));
            }
        }

        private RelayCommand exitProgram;
        public RelayCommand ExitProgram
        {
            get
            {
                return exitProgram ??
                  (exitProgram = new RelayCommand(obj =>
                  {
                      Application.Current.Shutdown();
                  }));
            }
        }

        private RelayCommand newProject;
        public RelayCommand NewProject
        {
            get
            {
                return newProject ??
                  (newProject = new RelayCommand(obj =>
                  {
                      //SaveFileDialog openFileDialog = new SaveFileDialog();
                      //openFileDialog.ShowDialog();
                  }));
            }
        }

        private RelayCommand openProject;
        public RelayCommand OpenProject
        {
            get
            {
                return newProject ??
                  (newProject = new RelayCommand(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.ShowDialog();
                  }));
            }
        }
    }
}
